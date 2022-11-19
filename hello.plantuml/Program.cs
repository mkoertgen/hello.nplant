// See https://aka.ms/new-console-template for more information

using System.Text;
using PlantUml.Net;

Console.WriteLine("Hello, World!");

using var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5000");
var uml = await client.GetStringAsync("/api/_Systems/ClusterSys/_plantuml");

var factory = new RendererFactory();
var renderer = factory.CreateRenderer(new PlantUmlSettings());

var bytes = await renderer.RenderAsync(uml, OutputFormat.Ascii);
Console.WriteLine(Encoding.UTF8.GetString(bytes));

bytes = await renderer.RenderAsync(uml, OutputFormat.Png);
File.WriteAllBytes("out.png", bytes);