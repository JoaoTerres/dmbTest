using dbm.Api.Context;
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

    public async Task AddAsync(Product produto)
    {
        await _context.Products.AddAsync(produto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product produto)
    {
        _context.Products.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var produto = await GetByIdAsync(id);
        if (produto != null)
        {
            _context.Products.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
