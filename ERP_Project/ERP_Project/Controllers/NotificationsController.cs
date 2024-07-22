using ERP_Project.Models;
using ERP_Project.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ERP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private readonly NotificationsService _NotificationsService;

        public NotificationsController(NotificationsService NotificationsService) =>
            _NotificationsService = NotificationsService;

        [HttpGet]
        public async Task<List<Notifications>> Get() =>
            await _NotificationsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Notifications>> Get(string id)
        {
            var Notification = await _NotificationsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            return Notification;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Notifications newNotifications)
        {
            await _NotificationsService.CreateAsync(newNotifications);

            return CreatedAtAction(nameof(Get), new { id = newNotifications.Id }, newNotifications.ToJson());
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Notifications updatedNotification)
        {
            var Notification = await _NotificationsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            updatedNotification.Id = Notification.Id;

            await _NotificationsService.UpdateAsync(id, updatedNotification);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Notification = await _NotificationsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            await _NotificationsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
