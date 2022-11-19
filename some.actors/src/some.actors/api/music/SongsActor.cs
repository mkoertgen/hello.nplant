using Akka.Actor;
using Akka.Event;

namespace some.actors.api.music;

public class SongsActor : ReceiveActor
{
    private readonly ILoggingAdapter _log = Context.GetLogger();

    public SongsActor()
    {
        Receive<PlaySongMessage>(HandlePlaySongMessage);
        Receive<PauseSongMessage>(HandlePauseSongMessage);
    }

    private void HandlePauseSongMessage(PauseSongMessage message)
    {
        _log.Info("Pausing song {0}", message.Song.Name);
    }

    private void HandlePlaySongMessage(PlaySongMessage message)
    {
        _log.Info("Playing song {0}", message.Song.Name);
    }
}