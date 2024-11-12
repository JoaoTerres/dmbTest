using dbm.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace dbm.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
