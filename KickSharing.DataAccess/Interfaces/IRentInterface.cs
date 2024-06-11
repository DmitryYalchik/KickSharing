using KickSharing.DataAccess.Models;

namespace KickSharing.DataAccess.Interfaces
{
    public interface IRentInterface<T> where T : Rent
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(string id);
        public Task<T> GetLast();
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<bool> Delete(string id);
    }
}
