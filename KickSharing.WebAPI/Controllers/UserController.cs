using System.ComponentModel.DataAnnotations;
using KickSharing.DataAccess.DTOs.User;
using KickSharing.DataAccess.Interfaces;
using KickSharing.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace KickSharing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface<User> userInterface;

        public UserController(IUserInterface<User> userInterface)
        {
            this.userInterface = userInterface;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? page, [FromQuery] int? take)
        {
            IEnumerable<User>? currentList = await userInterface.GetAll();
            if (page != null && take != null)
            {
                currentList = currentList.Skip(((int)page - 1) * (int)take).Take((int)take);
            }
            return Ok(currentList);
        }


        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([Required] string id)
        {
            if (await userInterface.GetById(id) == null)
                return NotFound();
            return Ok(await userInterface.GetById(id));
        }


        [HttpPost("{userId}/{isBlocked}")]
        public async Task<IActionResult> Block([Required] string userId, [Required] bool isBlocked)
        {
            if ((await userInterface.GetAll()).Count() == 0)
                return NotFound("Not a single user is registered");
            if (!(await userInterface.GetAll()).Any(x => x.Id == userId))
                return NotFound("User with this Id is not registered");
            if ((await userInterface.GetById(userId)).IsBlocked == isBlocked)
                return Conflict($"User block state already is {isBlocked}");
            var currentUser = await userInterface.GetById(userId);
            currentUser.IsBlocked = isBlocked;
            return Ok(await userInterface.Update(currentUser));
        }


        [HttpPost]
        public async Task<IActionResult> Post([Required, FromBody] RegisterUser registerUser)
        {
            if ((await userInterface.GetAll()).Any(x => x.Phone == registerUser.Phone))
                return Conflict("User with same Phone already is registered");
            return Ok(await userInterface.Create(new User(registerUser)));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([Required] string id, [Required, FromBody] UpdateUser updateUser)
        {
            if ((await userInterface.GetAll()).Count() == 0)
                return NotFound("Not a single User is registered");
            if (!(await userInterface.GetAll()).Any(x => x.Id == id))
                return NotFound("User with this Id is not registered");
            //if ((await userInterface.GetById(id)).Id != id)
            //{
            //    if ((await userInterface.GetAll()).Any(x => x.Identifier == updateUser.Identifier))
            //        return Conflict("Scooter with same Identifier already is registered");
            //}
            if ((await userInterface.GetAll()).Where(x => x.Id != id && (x.Phone == updateUser.Phone || x.Email == updateUser.Email)).Count() > 0)
            {
                return Conflict("Another User with same Phone or Email already is registered");
            }
            var currentUser = await userInterface.GetById(id);
            currentUser.Update(updateUser);
            return Ok(await userInterface.Update(currentUser));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            if (await userInterface.GetById(id) == null)
                return NotFound("User with this Id is not registered");
            if (await userInterface.Delete(id) == false)
                return BadRequest();
            return Ok();
        }
    }
}
