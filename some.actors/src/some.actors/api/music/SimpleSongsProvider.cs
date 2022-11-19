using System.Diagnostics.CodeAnalysis;

namespace some.actors.api.music;

public class SimpleSongsProvider : IProvideSongs
{
    private readonly IDictionary<string, Song> _songs = new Dictionary<string, Song>
    {
        {"Africa", new Song("Toto", "Africa", 1982)},
        {"Hold the Line", new Song("Toto", "Hold the Line", 1982)}
    };

    public IEnumerable<Song> GetAll()
    {
        return _songs.Values;
    }

    public bool TryGet(string name, [MaybeNullWhen(false)] out Song song)
    {
        return _songs.TryGetValue(name, out song);
    }
}