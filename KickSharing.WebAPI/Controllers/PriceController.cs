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

        /// <summary>
        /// Get all prices
        /// </summary>
        /// <param name="page">Pagination started from 1 page</param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? page, [FromQuery] int? take)
        {
            IEnumerable<Price>? currentList = await priceInterface.GetAll();
            if (page != null && take != null)
            {
                currentList = currentList.Skip(((int)page - 1) * (int)take).Take((int)take);
            }
            return Ok(currentList);
        }

        /// <summary>
        /// Get last (actual) price
        /// </summary>
        /// <returns></returns>
        [HttpGet("actual")]
        public async Task<IActionResult> GetLast()
        {
            if ((await priceInterface.GetAll()).Count() != 0)
                return NotFound();
            return Ok((await priceInterface.GetAll()).Last());
        }

        /// <summary>
        /// Get price by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] string id)
        {
            if (await priceInterface.GetById(id) != null)
                NotFound();
            return Ok(await priceInterface.GetById(id));
        }

        /// <summary>
        /// Create new price
        /// </summary>
        /// <param name="newPrice"></param>
        /// <returns></returns>
        [HttpPost("{newPrice}")]
        public async Task<IActionResult> Post([Required] double newPrice)
        {
            if ((await priceInterface.GetAll()).Count() != 0)
            {
                if ((await priceInterface.GetAll()).Last().MinutePrice == newPrice)
                {
                    return Conflict("This Price is already actual");
                }
            }
            return Ok(await priceInterface.Create(newPrice));
        }

        /// <summary>
        /// Delete price by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            if (await priceInterface.GetById(id) == null)
                return NotFound("Price with this Id is not registered");
            if (await priceInterface.Delete(id) == false)
                return BadRequest();
            return Ok();
        }
    }
}
