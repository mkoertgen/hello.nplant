using System.Diagnostics.CodeAnalysis;
using Akka.Actor;

namespace some.actors.api;

[SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
public record ActorSystemModel(
    string Name,
    TimeSpan UpTime,
    ActorModel? Guardian = null,
    ActorModel? SystemGuardian = null)
{
    public static ActorSystemModel From(ActorSystem system)
    {
        ActorModel? guardian = null;
        ActorModel? systemGuardian = null;
        if (system is ExtendedActorSystem extended)
        {
            guardian = ActorModel.From(extended.Guardian);
            systemGuardian = ActorModel.From(extended.SystemGuardian);
        }

        return new ActorSystemModel(
            system.Name,
            system.Uptime,
            guardian,
            systemGuardian
        );
    }
}