using dbm.Api.DTO;
using dbm.Api.Models;

namespace dbm.Api.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllAsync();
    Task<ProductDTO> GetByIdAsync(int id);
    Task AddAsync(ProductDTO productDto);
    Task UpdateAsync(ProductDTO productDto);
    Task DeleteAsync(int id);
}
