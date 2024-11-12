﻿using dbm.Api.Models;

namespace dbm.Api.Services.Interfaces;

public interface IProductService
{
    Task<Product> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}