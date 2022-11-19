using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace some.actors.api;

internal static class PlantUmlExtensions
{
    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    };

    public static string ToPlantUml<T>(this T value)
    {
        var str = new StringBuilder();
        str.AppendLine("@startjson");
        str.AppendLine(JsonSerializer.Serialize(value, JsonOpts));
        str.AppendLine("@endjson");
        return str.ToString();
    }
}