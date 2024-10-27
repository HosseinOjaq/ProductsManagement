using Rira.Domain.Enume;

namespace Rira.Domain.Entities;

public class Product
{
    public Product() { }

    internal Product(int id, string name, decimal price, Categories category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }
    public Categories Category { get; private set; }

    public static Product Create(int id, string name, decimal price, Categories category)
        => new Product(id, name, price, category);
}