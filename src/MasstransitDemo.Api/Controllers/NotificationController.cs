using MassTransit;
using MasstransitDemo.Api.Models;
using MasstransitDemo.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MasstransitDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(IPublishEndpoint publishEndpoint, ILogger<NotificationController> logger)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(NotificationDto),201,Type = typeof(NotificationDto))]
    public async Task<IActionResult> Notify([FromQuery] NotificationRequest notificationDto)
    {
        var response = new {
            notificationDto.NotificationDate,
            notificationDto.NotificationMessage,
            notificationDto.NotificationType,
            SubmissionStatus = SubmissionStatus.Submitted
        };
        //var json = JsonSerializer.Serialize(response, JsonSerializerOptions.Default);
        await _publishEndpoint.Publish<INotificationCreated>(response);
        _logger.LogInformation( 
            "NotificationCreated event published. Message: {NotificationDto}\n >> Status: {Status}",
            response, response.SubmissionStatus);
        
        
        
        return CreatedAtAction(nameof(Notify), response);
        
            
    }
}