using KickSharing.DataAccess.Models;

namespace KickSharing.DataAccess.Interfaces
{
    public interface IPriceInterface<T> where T : Price
    {
        public Task<IEnumerable<T>?> GetAll();
        public Task<T?> GetById(string id);
        public Task<T?> Create(double price);
        public Task<bool> Delete(string id);
    }
}
