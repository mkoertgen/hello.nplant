using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace some.actors.api.music;

public class MusicModule : AspNetCoreModule
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SimpleSongsProvider>().AsImplementedInterfaces().SingleInstance();
    }
}