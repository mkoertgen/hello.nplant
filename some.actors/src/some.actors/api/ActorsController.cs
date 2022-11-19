using Akka.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace some.actors.api;

[Route("api/_[controller]")]
public class ActorsController : ControllerBase
{
    private readonly IDictionary<string, ActorModel> _actors;

    public ActorsController(IReadOnlyActorRegistry registry)
    {
        _actors = registry.ToDictionary(x => x.Key.ToString(), x => ActorModel.From(x.Value)) ?? throw new ArgumentNullException(nameof(registry));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_actors.Keys);
    }

    [HttpGet("{key}")]
    public IActionResult Get(string key)
    {
        return _actors.TryGetValue(key, out var actor) ? Ok(actor) : NotFound();
    }
    
    [HttpGet("{key}/_plantuml")]
    [Produces("text/plain")]
    public IActionResult AsPlantUml(string key)
    {
        return _actors.TryGetValue(key, out var actor) ? Ok(actor.ToPlantUml()) : NotFound();
    }
}