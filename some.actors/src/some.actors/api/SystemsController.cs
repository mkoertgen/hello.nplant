using Akka.Actor;
using Microsoft.AspNetCore.Mvc;

namespace some.actors.api;

[Route("api/_[controller]")]
public class SystemsController : ControllerBase
{
    private readonly IDictionary<string, ActorSystemModel> _systems;

    public SystemsController(IEnumerable<ActorSystem> systems)
    {
        _systems = systems.ToDictionary(x => x.Name, x => ActorSystemModel.From(x));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_systems.Keys);
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        return _systems.TryGetValue(name, out var system) ? Ok(system) : NotFound();
    }

    [HttpGet("{name}/_plantuml")]
    [Produces("text/plain")]
    public IActionResult AsPlantUml(string name)
    {
        return _systems.TryGetValue(name, out var system) ? Ok(system.ToPlantUml()) : NotFound();
    }
}