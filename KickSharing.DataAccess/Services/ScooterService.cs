using KickSharing.DataAccess.Interfaces;
using KickSharing.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KickSharing.DataAccess.Services
{
    public class ScooterService : IScooterInterface<Scooter>
    {
        private readonly AppDBContext db;

        public ScooterService(AppDBContext _db)
        {
            db = _db;
        }

        public async Task<Scooter> Create(Scooter entity)
        {
            var currentScooter = await db.Scooters.AddAsync(entity);
            await db.SaveChangesAsync();
            return currentScooter.Entity;
        }

        public async Task<bool> Delete(string id)
        {
            if (GetById(id) != null)
            {
                db.Scooters.Remove(await GetById(id));
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Scooter>> GetAll()
        {
            return await db.Scooters.ToListAsync();
        }

        public async Task<Scooter> GetById(string id)
        {
            return await db.Scooters.FirstAsync(x => x.Id == id);
        }

        public async Task<Scooter> Update(Scooter entity)
        {
            var currentScooter = db.Scooters.Update(entity);
            await db.SaveChangesAsync();
            return currentScooter.Entity;
        }
    }
}
