using System.Diagnostics.CodeAnalysis;
using Akka.Actor;

namespace some.actors.api;

[SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
public record ActorModel(long Uid,
    string Name,
    string Path,
    ActorModel[]? Children = null)
{
    public static ActorModel From(IActorRef actorRef)
    {
        var cellActor = actorRef as ActorRefWithCell;
        var children = cellActor?.Children.Select(From).ToArray();
        return new ActorModel(
            Uid: actorRef.Path.Uid,
            Name: actorRef.Path.Name,
            Path: actorRef.Path.ToString(),
            Children: children?.Any() == true ? children : null
        );
    }
}