using System.Diagnostics.CodeAnalysis;

namespace some.actors.api.music;

[SuppressMessage("ReSharper", "NotAccessedPositionalProperty.Global")]
public record Song(string Artist, string Name, int Year);

public record SongMessage(Song Song);

public record PlaySongMessage(Song Song) : SongMessage(Song);

public record PauseSongMessage(Song Song) : SongMessage(Song);