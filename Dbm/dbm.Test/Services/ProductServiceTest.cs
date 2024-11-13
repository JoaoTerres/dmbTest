using Moq;
using AutoMapper;
using Xunit;
using dbm.Api.Services;
using dbm.Api.Repositories.Interfaces;
using dbm.Api.Models;
using dbm.Api.DTO;




namespace dbm.Test.Services;

public class ProductServiceTest
{
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly IMapper _mapper;
    private readonly ProductService _productService;

    public ProductServiceTest()
    {
        var mappingConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Product, ProductDTO>().ReverseMap();
        });
        _mapper = mappingConfig.CreateMapper();

        _mockProductRepository = new Mock<IProductRepository>();

        _productService = new ProductService(_mockProductRepository.Object, _mapper);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllProducts()
    {
        var mockProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Product1" },
                new Product { Id = 2, Name = "Product2" }
            };
        _mockProductRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockProducts);

        var result = await _productService.GetAllAsync();

        Assert.Equal(2, result.Count());
        Assert.Contains(result, p => p.Name == "Product1");
        Assert.Contains(result, p => p.Name == "Product2");
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsProductById()
    {
        var product = new Product { Id = 1, Name = "Product1" };
        _mockProductRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

        var result = await _productService.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("Product1", result.Name);
    }

    [Fact]
    public async Task AddAsync_AddsProductSuccessfully()
    {
        var productDto = new ProductDTO { Id = 1, Name = "Product1" };
        var product = new Product { Id = 1, Name = "Product1" };

        _mockProductRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>())).ReturnsAsync(product);

        await _productService.AddAsync(productDto);

        _mockProductRepository.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_UpdatesProductSuccessfully()
    {
        var productDto = new ProductDTO { Id = 1, Name = "UpdatedProduct" };
        var product = new Product { Id = 1, Name = "Product1" };

        _mockProductRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(product);

        await _productService.UpdateAsync(productDto);

        _mockProductRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_DeletesProductSuccessfully()
    {
        var product = new Product { Id = 1, Name = "Product1" };
        _mockProductRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);
        _mockProductRepository.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(product);

        await _productService.DeleteAsync(1);

        _mockProductRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
    }
}

