using System.Text;
using Rira.Domain.Enume;

namespace Rira.Domain.Dtos.Products;

public class ProductsGroupedByCategoryDto
{
    public Categories Category { get; set; }
    public List<ProductDto> Products { get; set; } = [];

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Category: {Category}");

        builder.AppendLine("Products:");
        foreach (var product in Products)
            builder.AppendLine($"\t {product}");

        return builder.ToString();
    }
}