using dbm.Api.Models;
using dbm.Api.Repositories.Interfaces;
using dbm.Api.Services.Interfaces;

namespace dbm.Api.Services;


public class ProductService : IProductService
{
    private readonly IProductRepository _produtoRepository;

    public ProductService(IProductRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _produtoRepository.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _produtoRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Product product)
    {
        await _produtoRepository.AddAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        await _produtoRepository.UpdateAsync(product);
    }
    public async Task DeleteAsync(int id)
    {
        await _produtoRepository.DeleteAsync(id);
    }
}

