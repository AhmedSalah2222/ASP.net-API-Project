using ERP_Project.Models;
using ERP_Project.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ERP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersService _UsersService;

        public UsersController(UsersService NotificationsService) =>
            _UsersService = NotificationsService;

        [HttpGet]
        public async Task<List<Users>> Get() =>
            await _UsersService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Users>> Get(string id)
        {
            var Notification = await _UsersService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            return Notification;
        }

        [HttpGet("{user_email}")]
        public async Task<ActionResult<Users>> GetByEmail(string user_email)
        {
            var Notification = await _UsersService.GetEmailAsync(user_email);

            if (Notification is null)
            {
                return NotFound();
            }

            return Notification;
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody]
 Users newNotifications)
        {
            await _UsersService.CreateAsync(newNotifications);

            return CreatedAtAction(nameof(Get), new { id = newNotifications.Id }, newNotifications.ToJson());
        }



        [HttpPost("create")]
        public async Task<IActionResult> Post(List<Users> usersList)
        {
            /*var users = new List<Users>();
            foreach (var userMap in usersList)
            {
                var user = new Users();
                foreach (var kvp in userMap)
                {
                    // Assuming User class has properties matching the keys in the dictionary
                    typeof(Users).GetProperty(kvp.Key)?.SetValue(user, kvp.Value);
                }
                
                await _UsersService.CreateAsync(user);
            }*/
            await _UsersService.CreateAsyncList(usersList);

            return Ok("Users created successfully.");
        }



        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Users updatedNotification)
        {
            var Notification = await _UsersService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            updatedNotification.Id = Notification.Id;

            await _UsersService.UpdateAsync(id, updatedNotification);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Notification = await _UsersService.GetAsync(id);

            if (Notification is null)
            {
                return NotFound();
            }

            await _UsersService.RemoveAsync(id);

            return NoContent();
        }
    }
}
