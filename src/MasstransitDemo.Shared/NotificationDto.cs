namespace MasstransitDemo.Shared;

public record NotificationDto(
    [property: JsonPropertyName("notificationDate")]
    DateTime NotificationDate,
    [property: JsonPropertyName("notificationMessage")]
    string? NotificationMessage,
    [property: JsonPropertyName("notificationType")]
    NotificationType NotificationType
)
{
    [JsonPropertyName("status")] public SubmissionStatus Status { get; set; }
}