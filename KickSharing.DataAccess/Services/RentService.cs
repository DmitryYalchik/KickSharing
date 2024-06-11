using KickSharing.DataAccess.Interfaces;
using KickSharing.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KickSharing.DataAccess.Services
{
    public class RentService : IRentInterface<Rent>
    {
        private readonly AppDBContext db;

        public RentService(AppDBContext _db)
        {
            db = _db;
        }

        public async Task<Rent> Create(Rent entity)
        {
            var currentRent = await db.Rents.AddAsync(entity);
            await db.SaveChangesAsync();
            return currentRent.Entity;
        }

        public async Task<bool> Delete(string id)
        {
            if (GetById(id) != null)
            {
                db.Rents.Remove(await GetById(id));
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Rent>> GetAll()
        {
            return await db.Rents.ToListAsync();
        }

        public async Task<Rent> GetById(string id)
        {
            return await db.Rents.FirstAsync(x => x.Id == id);
        }

        public async Task<Rent> GetLast()
        {
            return await db.Rents.LastAsync();
        }

        public async Task<Rent> Update(Rent entity)
        {
            var currentRent = db.Rents.Update(entity);
            await db.SaveChangesAsync();
            return currentRent.Entity;
        }
    }
}
