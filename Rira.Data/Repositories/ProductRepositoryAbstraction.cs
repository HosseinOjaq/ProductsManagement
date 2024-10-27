using Rira.Domain.Enume;
using Rira.Domain.Dtos.Products;

namespace Rira.Data.Repositories;

public abstract class ProductRepositoryAbstraction
{
    public abstract decimal AveragePrice();
    public abstract decimal SumPrices();
    public abstract ProductDto? GetMaxPriceProduct();
    public abstract List<ProductDto> GetByCategoryId(Categories Category);
    public abstract List<ProductsGroupedByCategoryDto> GroupedByCategory();
}