using KickSharing.DataAccess.Interfaces;
using KickSharing.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KickSharing.DataAccess.Services
{
    public class PriceService : IPriceInterface<Price>
    {
        private readonly AppDBContext db;

        public PriceService(AppDBContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// Create new Price
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public async Task<Price?> Create(double price)
        {
            var addedPrice = await db.Prices.AddAsync(new Price(price));
            await db.SaveChangesAsync();
            return addedPrice.Entity;
        }

        /// <summary>
        /// Delete some Price by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            if (await GetById(id) != null)
            {
                db.Prices.Remove(await GetById(id));
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get all Prices
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Price>?> GetAll()
        {
            return await db.Prices.ToListAsync();
        }

        /// <summary>
        /// Get some Price by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Price?> GetById(string id)
        {
            return await db.Prices.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
