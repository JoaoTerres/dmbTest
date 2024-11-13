using dbm.Api.DTO;
using dbm.Api.Models;

namespace dbm.Api.Repositories.Interfaces;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByNameAsync(string name);
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product> DeleteAsync(int id);
}
