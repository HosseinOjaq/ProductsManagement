using Rira.Domain.Enume;
using Rira.Domain.Entities;

namespace Rira.Data.Context;

public sealed class RiraDbContext
{
    private readonly List<Product> products =
    [
        Product.Create(1, "Product A", 100, Categories.Category1),
        Product.Create(2, "Product B", 150, Categories.Category1),
        Product.Create(3, "Product C", 120, Categories.Category2),
        Product.Create(4, "Product D", 200, Categories.Category3),
        Product.Create(5, "Product E", 80, Categories.Category1)
    ];

    internal List<Product> GetProducts() => products;
}