using System.ComponentModel.DataAnnotations;
using KickSharing.DataAccess.Interfaces;
using KickSharing.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KickSharing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceInterface<Price> priceInterface;

        public PriceController(IPriceInterface<Price> priceInterface)
        {
            this.priceInterface = priceInterface;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await priceInterface.GetAll());
        }

        [HttpGet("actual")]
        public async Task<IActionResult> GetLast()
        {
            return Ok(priceInterface.GetAll().Result.Last());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] string id)
        {
            return Ok(await priceInterface.GetById(id));
        }


        [HttpPost("{newPrice}")]
        public async Task<IActionResult> Post([Required] double newPrice)
        {
            return Ok(await priceInterface.Create(newPrice));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            return await priceInterface.Delete(id) == true ? Ok(new { success = true }) : BadRequest(new { success = false });
        }
    }
}
