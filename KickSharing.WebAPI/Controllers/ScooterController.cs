using System.ComponentModel.DataAnnotations;
using KickSharing.DataAccess.DTOs.Scooter;
using KickSharing.DataAccess.Interfaces;
using KickSharing.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace KickSharing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScooterController : ControllerBase
    {
        private readonly IScooterInterface<Scooter> scooterInterface;

        public ScooterController(IScooterInterface<Scooter> scooterInterface)
        {
            this.scooterInterface = scooterInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? page, [FromQuery] int? take)
        {
            IEnumerable<Scooter>? currentList = await scooterInterface.GetAll();
            if (page != null && take != null)
            {
                currentList = currentList.Skip(((int)page - 1) * (int)take).Take((int)take);
            }
            return Ok(currentList);
        }


        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([Required] string id)
        {
            if (await scooterInterface.GetById(id) == null)
                return NotFound();
            return Ok(await scooterInterface.GetById(id));
        }

        [HttpGet("identifier/{identifier}")]
        public async Task<IActionResult> GetByIdentifier([Required] string identifier)
        {

            if ((await scooterInterface.GetAll()).Where(x => x.Identifier == identifier).FirstOrDefault() == null)
                return NotFound();
            return Ok((await scooterInterface.GetAll()).Where(x => x.Identifier == identifier).FirstOrDefault());
        }


        [HttpPost("{scooterId}/{isBlocked}")]
        public async Task<IActionResult> Block([Required] string scooterId, [Required] bool isBlocked)
        {
            if ((await scooterInterface.GetAll()).Count() == 0)
                return NotFound("Not a single scooter is registered");
            if (!(await scooterInterface.GetAll()).Any(x => x.Id == scooterId))
                return NotFound("Scooter with this Id is not registered");
            if ((await scooterInterface.GetById(scooterId)).IsBlocked == isBlocked)
                return Conflict($"Scooter block state already is {isBlocked}");
            var currentScooter = await scooterInterface.GetById(scooterId);
            currentScooter.IsBlocked = isBlocked;
            return Ok(await scooterInterface.Update(currentScooter));
        }


        [HttpPost]
        public async Task<IActionResult> Post([Required, FromBody] RegisterScooter registerScooter)
        {
            if ((await scooterInterface.GetAll()).Any(x => x.Identifier == registerScooter.Identifier))
                return Conflict("Scooter with same Identifier already is registered");
            return Ok(await scooterInterface.Create(new Scooter(registerScooter)));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([Required] string id, [Required, FromBody] UpdateScooter updateScooter)
        {
            if ((await scooterInterface.GetAll()).Count() == 0)
                return NotFound("Not a single scooter is registered");
            if (!(await scooterInterface.GetAll()).Any(x => x.Id == id))
                return NotFound("Scooter with this Id is not registered");
            if ((await scooterInterface.GetById(id)).Identifier != updateScooter.Identifier)
            {
                if ((await scooterInterface.GetAll()).Any(x => x.Identifier == updateScooter.Identifier))
                    return Conflict("Scooter with same Identifier already is registered");
            }
            var currentScooter = await scooterInterface.GetById(id);
            currentScooter.Update(updateScooter);
            return Ok(await scooterInterface.Update(currentScooter));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            if (await scooterInterface.GetById(id) == null)
                return NotFound("Scooter with this Id is not registered");
            if (await scooterInterface.Delete(id) == false)
                return BadRequest();
            return Ok();
        }
    }
}
