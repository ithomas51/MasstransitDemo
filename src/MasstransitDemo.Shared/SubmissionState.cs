namespace MasstransitDemo.Shared;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubmissionStatus
{
    [JsonPropertyName("submitted")]
    Submitted,
    [JsonPropertyName("accepted")]
    Accepted,
    [JsonPropertyName("rejected")]
    Rejected
}