using System.Text.Json;

namespace BasketballGame.Core.Persistence
{
    internal static class JsonUtil
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public static string ToJson<T>(T obj) => JsonSerializer.Serialize(obj, Options);
        public static T? FromJson<T>(string json) => JsonSerializer.Deserialize<T>(json, Options);
    }
}
