using KickSharing.DataAccess.Interfaces;
using KickSharing.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KickSharing.DataAccess.Services
{
    public class UserService : IUserInterface<User>
    {
        private readonly AppDBContext db;

        public UserService(AppDBContext _db)
        {
            db = _db;
        }

        public async Task<User> Create(User entity)
        {
            var currentUser = await db.Users.AddAsync(entity);
            await db.SaveChangesAsync();
            return currentUser.Entity;
        }

        public async Task<bool> Delete(string id)
        {
            if (GetById(id) != null)
            {
                db.Users.Remove(await GetById(id));
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await db.Users.FirstAsync(x => x.Id == id);
        }

        public async Task<User> Update(User entity)
        {
            var currentUser = db.Users.Update(entity);
            await db.SaveChangesAsync();
            return currentUser.Entity;
        }
    }
}
