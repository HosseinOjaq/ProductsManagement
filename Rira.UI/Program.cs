using Rira.Domain.Enume;
using Rira.Data.Repositories;

var productRepository = new ProductRepository();

var productsWithCategoryOne = productRepository.GetByCategoryId(Categories.Category1);
foreach (var product in productsWithCategoryOne)
    Console.WriteLine(product);

SpaceBetweenData();

var averageProductPrice = productRepository.AveragePrice();
Console.WriteLine($"Average Product Price: {averageProductPrice}");

SpaceBetweenData();

var productWithMaxPrice = productRepository.GetMaxPriceProduct();
if (productWithMaxPrice is not null)
Console.WriteLine($"Product With Max Price: {productWithMaxPrice}");

SpaceBetweenData();

var sumPrices = productRepository.SumPrices();
Console.WriteLine($"Product Sum Prices: {sumPrices}");

SpaceBetweenData();

var groupedProducts = productRepository.GroupedByCategory();
Console.WriteLine("Grouped By Product Category:");
foreach (var product in groupedProducts)
    Console.WriteLine(product);

void SpaceBetweenData()
{
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("");
}

Console.ReadKey();