using MassTransit;
using MasstransitDemo.Shared;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MasstransitDemo.Consumer;

public class NotificationCreatedConsumer : IConsumer<INotificationCreated>
{
    private readonly ILogger<NotificationCreatedConsumer> _logger;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    public NotificationCreatedConsumer(ILogger<NotificationCreatedConsumer> logger)
    {
        _logger = logger;
        _jsonSerializerOptions = new()
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }
    
    public async Task Consume(ConsumeContext<INotificationCreated> context)
    {
        var result = new NotificationDto(context.Message.NotificationDate, context.Message.NotificationMessage, context.Message.NotificationType)
        {
            Status = SubmissionStatus.Submitted
        };

        context.Message.Status = SubmissionStatus.Submitted;
       // var serializedMessage = JsonSerializer.Serialize<INotificationCreated>(context.Message, _jsonSerializerOptions);
        var serializedMessage = JsonSerializer.Serialize<INotificationCreated>(context.Message, _jsonSerializerOptions);

       _logger.LogInformation(
           "NotificationCreated event consumed. Message: {SerializedMessage}", serializedMessage);
        
        await Task.CompletedTask;
    }
}