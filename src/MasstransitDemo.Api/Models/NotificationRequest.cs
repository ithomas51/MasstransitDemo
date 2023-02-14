using MasstransitDemo.Shared;
using System.Text.Json.Serialization;

namespace MasstransitDemo.Api.Models
{
    public record NotificationRequest
    {
        public DateTime NotificationDate { get; set; }
        public string? NotificationMessage { get; set; } = null;
        public NotificationType NotificationType { get; set; }
    }


}