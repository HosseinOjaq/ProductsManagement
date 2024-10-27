using Rira.Domain.Enume;

namespace Rira.Domain.Dtos.Products;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public Categories Category { get; set; }


    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Category: {Category}, Price: {Price}";
    }
}