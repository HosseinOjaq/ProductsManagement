using Domain.Enume;
using Rira.Data.Context;
using Rira.Data.Contract;
using Rira.Data.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<ApplicationDbContext>();
        services.AddSingleton<DbContext, ApplicationDbContext>();
        services.AddScoped<IProductRepository, ProductRepository>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

    var productsWithCategoryOne = productRepository.GetByCategoryId(Categories.Category1);
    foreach (var product in productsWithCategoryOne)
        Console.WriteLine(product);

    SpaceBetweenData();

    var averageProductPrice = productRepository.AveragePrice();
    Console.WriteLine($"Average Product Price: {averageProductPrice}");

    SpaceBetweenData();

    var productWithMaxPrice = productRepository.GetMaxPriceProduct();
    Console.WriteLine($"Product With Max Price: {productWithMaxPrice}");

    SpaceBetweenData();

    var sumPrices = productRepository.SumPrices();
    Console.WriteLine($"Product Sum Prices: {sumPrices}");

    SpaceBetweenData();

    var groupedProducts = productRepository.GroupedByCategory();
    Console.WriteLine("Grouped By Product Category:");
    foreach (var product in groupedProducts)
        Console.WriteLine(product);
}

void SpaceBetweenData()
{
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("");
}

Console.ReadKey();