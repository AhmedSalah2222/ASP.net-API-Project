using ERP_Project.Models;
using ERP_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : Controller
    {
        private readonly PermissionsService _PermissionsService;

        public PermissionsController(PermissionsService NotificationsService) =>
            _PermissionsService = NotificationsService;

        [HttpGet]
        public async Task<List<Permissions>> Get() =>
            await _PermissionsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Permissions>> Get(string id)
        {
            var Notification = await _PermissionsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            return Notification;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Permissions newNotifications)
        {
            await _PermissionsService.CreateAsync(newNotifications);

            return CreatedAtAction(nameof(Get), new { id = newNotifications.Id }, newNotifications);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Permissions updatedNotification)
        {
            var Notification = await _PermissionsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            updatedNotification.Id = Notification.Id;

            await _PermissionsService.UpdateAsync(id, updatedNotification);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Notification = await _PermissionsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            await _PermissionsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
