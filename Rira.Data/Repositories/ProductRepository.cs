using Rira.Data.Context;
using Rira.Domain.Enume;
using Rira.Domain.Dtos.Products;

namespace Rira.Data.Repositories
{
    public sealed class ProductRepository : ProductRepositoryAbstraction
    {
        private readonly RiraDbContext context;

        public ProductRepository()
        {
            context = new RiraDbContext();
        }

        public override List<ProductDto> GetByCategoryId(Categories Category)
        {
            var products = context
                .GetProducts()
                .Where(product => product.Category == Category)
                .Select(product => new ProductDto
                {
                    Id = product.Id,
                    Category = product.Category,
                    Name = product.Name,
                    Price = product.Price,
                }).ToList();
            return products;
        }

        public override ProductDto? GetMaxPriceProduct()
        {
            var product = context
                .GetProducts()
                .OrderByDescending(product => product.Price)
                .FirstOrDefault();

            if (product is null)
                return null;

            var result = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
            };
            return result;
        }

        public override decimal SumPrices()
        {
            var sumPrices = context
                .GetProducts()
                .Sum(product => product.Price);

            return sumPrices;
        }

        public override List<ProductsGroupedByCategoryDto> GroupedByCategory()
        {
            var products = context
                .GetProducts()
                .GroupBy(product => product.Category)
                .Select(product => new ProductsGroupedByCategoryDto
                {
                    Category = product.Key,
                    Products = product.Select(product => new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Category = product.Category,
                    }).ToList(),
                }).ToList();
            return products;
        }

        public override decimal AveragePrice()
        {
            var averagePrice = context.GetProducts().Average(product => product.Price);
            return averagePrice;
        }
    }
}