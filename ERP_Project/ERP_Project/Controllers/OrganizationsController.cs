using ERP_Project.Models;
using ERP_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace ERP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : Controller
    {
        private readonly OrganizationsService _OrganizationsService;

        public OrganizationsController(OrganizationsService NotificationsService) =>
            _OrganizationsService = NotificationsService;

        [HttpGet]
        public async Task<List<Organizations>> Get() =>
            await _OrganizationsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Organizations>> Get(string id)
        {
            var Notification = await _OrganizationsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            return Notification;
        }


        ///////
        [HttpGet("OrgID/{Organization_ID}")]
        public async Task<ActionResult<Organizations>> GetByOrganizationId(string Organization_ID)
        {
            var organization = await _OrganizationsService.GetOrgIdAsync(Organization_ID);

            if (organization is null)
            {
                return NotFound();
            }

            return organization;
        }


        //[HttpGet("{License_ID}")]
        [HttpGet("license/{License_ID}")]
        public async Task<ActionResult<Organizations>> GetByOrganizationLicenseId(string License_ID)
        {
            var organization = await _OrganizationsService.GetLicenseIdAsync(License_ID);

            if (organization is null)
            {
                return NotFound();
            }

            return organization;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Organizations newNotifications)
        {
            await _OrganizationsService.CreateAsync(newNotifications);

            return CreatedAtAction(nameof(Get), new { id = newNotifications.Id }, newNotifications);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Organizations updatedNotification)
        {
            var Notification = await _OrganizationsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            updatedNotification.Id = Notification.Id;

            await _OrganizationsService.UpdateAsync(id, updatedNotification);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Notification = await _OrganizationsService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            await _OrganizationsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
