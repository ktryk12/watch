using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification_Microservice.Dto;
using Notification_Microservice.Serviceslag;
using System.Threading.Tasks;

namespace Notification_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        [HttpGet("{notificationId}")]
        [Authorize]
        public async Task<IActionResult> GetNotificationById(int notificationId)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(notificationId);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationDto notificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _notificationService.CreateNotificationAsync(notificationDto);
            return CreatedAtAction(nameof(GetNotificationById), new { notificationId = notificationDto.NotificationId }, notificationDto);
        }

        [HttpPut("{notificationId}")]
        [Authorize]
        public async Task<IActionResult> UpdateNotification(int notificationId, [FromBody] NotificationDto notificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _notificationService.UpdateNotificationAsync(notificationId, notificationDto);
            return NoContent(); // 204 No Content er en passende statuskode for en vellykket PUT-anmodning uden et respons body.
        }

        [HttpDelete("{notificationId}")]
        [Authorize]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            await _notificationService.DeleteNotificationAsync(notificationId);
            return NoContent();
        }
    }
}
