using Akka.Actor;
using Akka.Event;
using Microsoft.AspNetCore.Mvc;

namespace some.actors.api.music;

[Route("api/music/[controller]")]
public class SongsController : ControllerBase
{
    private readonly IProvideSongs _service;
    private readonly EventStream _events;

    public SongsController(IProvideSongs service, ActorSystem system)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _events = system.EventStream ?? throw new ArgumentNullException(nameof(system));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
        return _service.TryGet(name, out var song) ? Ok(song) : NotFound();
    }

    [HttpPost("{name}/_play")]
    public IActionResult Play(string name)
    {
        if (!_service.TryGet(name, out var song)) return NotFound();
        _events.Publish(new PlaySongMessage(song));
        return Ok(song);
    }

    [HttpPost("{name}/_pause")]
    public IActionResult Pause(string name)
    {
        if (!_service.TryGet(name, out var song)) return NotFound();
        _events.Publish(new PauseSongMessage(song));
        return Ok(song);
    }
}