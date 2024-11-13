using dbm.Api.Context;
using dbm.Api.Models;
using dbm.Api.Repositories;
using Microsoft.EntityFrameworkCore;

using Xunit;

namespace dbm.Test.Repositories;

public class ProductRepositoryTests
{
    private readonly AppDbContext _context;
    private readonly ProductRepository _repository;

    public ProductRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb") 
            .Options;

        _context = new AppDbContext(options);
        _repository = new ProductRepository(_context);
    }

    [Fact]
    public async Task AddAsync_ShouldAddProduct()
    {
        var product = new Product
        {
            Name = "Test Product",
            Description = "A sample product",
            Price = 10.99M
        };

        var result = await _repository.AddAsync(product);

        var addedProduct = await _context.Products.FindAsync(result.Id);
        Assert.NotNull(addedProduct);
        Assert.Equal("Test Product", addedProduct.Name);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnProduct()
    {
        var product = new Product
        {
            Name = "Product for GetById",
            Description = "Description",
            Price = 5.99M
        };
        var addedProduct = await _repository.AddAsync(product);

        var result = await _repository.GetByIdAsync(addedProduct.Id);

        Assert.NotNull(result);
        Assert.Equal(addedProduct.Id, result.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnProducts()
    {
        await _repository.AddAsync(new Product { Name = "Product 1", Price = 5.99M });
        await _repository.AddAsync(new Product { Name = "Product 2", Price = 15.99M });

        var result = await _repository.GetAllAsync();

        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnProduct()
    {
        var product = new Product
        {
            Name = "Unique Product",
            Description = "Description",
            Price = 12.99M
        };
        await _repository.AddAsync(product);

        var result = await _repository.GetByNameAsync("Unique Product");

        Assert.NotNull(result);
        Assert.Equal("Unique Product", result.Name);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateProduct()
    {
        var product = new Product
        {
            Name = "Old Name",
            Description = "Description",
            Price = 9.99M
        };
        var addedProduct = await _repository.AddAsync(product);
        addedProduct.Name = "Updated Name";

        var updatedProduct = await _repository.UpdateAsync(addedProduct);

        var result = await _context.Products.FindAsync(updatedProduct.Id);
        Assert.NotNull(result);
        Assert.Equal("Updated Name", result.Name);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteProduct()
    {
        var product = new Product
        {
            Name = "Product to Delete",
            Description = "Description",
            Price = 19.99M
        };
        var addedProduct = await _repository.AddAsync(product);

        var deletedProduct = await _repository.DeleteAsync(addedProduct.Id);

        var result = await _context.Products.FindAsync(deletedProduct.Id);
        Assert.Null(result);
    }
}
