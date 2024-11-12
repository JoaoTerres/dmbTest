namespace dbm.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime _ts_Create { get; set; } = DateTime.UtcNow;
}
