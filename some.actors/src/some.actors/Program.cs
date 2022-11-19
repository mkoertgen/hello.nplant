using System.Diagnostics;
using Akka.Actor;
using Akka.Cluster.Hosting;
using Akka.Hosting;
using Akka.Remote.Hosting;
using Autofac.Extensions.DependencyInjection;
using some.actors;
using Petabridge.Cmd.Cluster;
using Petabridge.Cmd.Cluster.Sharding;
using Petabridge.Cmd.Host;
using Petabridge.Cmd.Remote;
using some.actors.api.music;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

var builder = WebApplication.CreateBuilder(args);

// Add AutoFac: https://stackoverflow.com/questions/69754985/adding-autofac-to-net-core-6-0-using-the-new-single-file-template
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Configuration.AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{environment}.json");

builder.Logging.ClearProviders().AddConsole();

var akkaConfig = builder.Configuration.GetRequiredSection(nameof(AkkaClusterConfig))
    .Get<AkkaClusterConfig>();

builder.Services.AddControllers();
builder.Services.AddAkka(akkaConfig.ActorSystemName, (akkBuilder, _) =>
{
    Debug.Assert(akkaConfig.Port != null, "akkaConfig.Port != null");
    akkBuilder.AddHoconFile("app.conf")
        .WithRemoting(akkaConfig.Hostname, akkaConfig.Port.Value)
        .WithClustering(new ClusterOptions()
        {
            Roles = akkaConfig.Roles?.ToArray() ?? Array.Empty<string>(),
            SeedNodes = akkaConfig.SeedNodes?.Select(Address.Parse).ToArray() ?? Array.Empty<Address>()
        })
        .AddPetabridgeCmd(cmd =>
        {
            cmd.RegisterCommandPalette(new RemoteCommands());
            cmd.RegisterCommandPalette(ClusterCommands.Instance);

            // sharding commands, although the app isn't configured to host any by default
            cmd.RegisterCommandPalette(ClusterShardingCommands.Instance);
        })
        .WithActors((system, registry) =>
        {
            var consoleActor = system.ActorOf(Props.Create(() => new ConsoleActor()), "console");
            registry.Register<ConsoleActor>(consoleActor);

            var songsActor = system.ActorOf(Props.Create(() => new SongsActor()), "songs");
            registry.Register<SongsActor>(songsActor);
            system.EventStream.Subscribe(songsActor, typeof(SongMessage));
        });
});

builder.Services.AddSwaggerGen();

// 1. Register Autofac/AspNetModules
var modules = builder.UseModules()
    .With(new SettingsModule(builder.Configuration))
    .Scanning(new[] {typeof(Program).Assembly, typeof(SettingsModule).Assembly})
    .Build();


var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapGet("/", async (HttpContext context, ActorRegistry registry) =>
    {
        var reporter = registry.Get<ConsoleActor>();
        var resp = await reporter.Ask<string>($"hit from {context.TraceIdentifier}",
            context.RequestAborted); // calls Akka.NET under the covers
        await context.Response.WriteAsync(resp);
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 2. Use Autofac/AspNetModules
modules.Use(app);

await app.RunAsync();