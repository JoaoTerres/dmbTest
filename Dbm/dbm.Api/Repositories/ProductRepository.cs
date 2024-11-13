using dbm.Api.Context;
using dbm.Api.DTO;
using dbm.Api.Models;
using dbm.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dbm.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByNameAsync(string name)
    {
        return await _context.Products
            .Where(p => p.Name == name)
            .FirstOrDefaultAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }


}
