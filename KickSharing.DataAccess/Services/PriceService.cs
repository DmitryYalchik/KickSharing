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

        public async Task<Price> Create(double price)
        {
            var addedPrice = await db.Prices.AddAsync(new Price(price));
            await db.SaveChangesAsync();
            return addedPrice.Entity;
        }

        public async Task<bool> Delete(string id)
        {
            if (GetById(id) != null)
            {
                db.Prices.Remove(await GetById(id));
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Price>> GetAll()
        {
            return await db.Prices.ToListAsync();
        }

        public async Task<Price> GetById(string id)
        {
            return await db.Prices.FirstAsync(x => x.Id == id);
        }
    }
}
