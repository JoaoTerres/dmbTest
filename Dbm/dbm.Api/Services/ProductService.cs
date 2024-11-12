using AutoMapper;
using dbm.Api.DTO;
using dbm.Api.Models;
using dbm.Api.Repositories.Interfaces;
using dbm.Api.Services.Interfaces;

namespace dbm.Api.Services;


public class ProductService : IProductService
{
    private readonly IProductRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository produtoRepository, IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var products = await _produtoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        var product = await _produtoRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task AddAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _produtoRepository.AddAsync(product);
    }

    public async Task UpdateAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _produtoRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        await _produtoRepository.DeleteAsync(id);
    }
}

