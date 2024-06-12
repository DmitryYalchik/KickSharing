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

        /// <summary>
        /// Create new Rent
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Rent?> Create(Rent entity)
        {
            var currentRent = await db.Rents.AddAsync(entity);
            await db.SaveChangesAsync();
            return currentRent.Entity;
        }

        /// <summary>
        /// Delete some Rent by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            if (await GetById(id) != null)
            {
                db.Rents.Remove(await GetById(id));
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get all Rents
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Rent>?> GetAll()
        {
            return await db.Rents.ToListAsync();
        }

        /// <summary>
        /// Get some Rent by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Rent?> GetById(string id)
        {
            return await db.Rents.LastOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Get last (actual) Rent
        /// </summary>
        /// <returns></returns>
        public async Task<Rent?> GetLast()
        {
            return await db.Rents.LastOrDefaultAsync();
        }

        /// <summary>
        /// Update some Rent
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Rent?> Update(Rent entity)
        {
            var currentRent = db.Rents.Update(entity);
            await db.SaveChangesAsync();
            return currentRent.Entity;
        }
    }
}
