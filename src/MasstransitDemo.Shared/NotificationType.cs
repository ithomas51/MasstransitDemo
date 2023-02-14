namespace MasstransitDemo.Shared;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NotificationType
{
    [JsonPropertyName("email")]
    Email,
    [JsonPropertyName("push")]
    Push,
    [JsonPropertyName("sms")]
    Sms
}