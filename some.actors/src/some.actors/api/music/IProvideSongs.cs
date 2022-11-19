using System.Diagnostics.CodeAnalysis;

namespace some.actors.api.music;

public interface IProvideSongs
{
    IEnumerable<Song> GetAll();
    bool TryGet(string name, [MaybeNullWhen(false)] out Song song);
}