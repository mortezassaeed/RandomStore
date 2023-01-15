using System.CodeDom.Compiler;

namespace GroceryStore;

internal class Product
{
    public required Guid EntityId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public DateTime FetchDate { get; set; }
}


internal class ProductService
{
    private List<Product> _products { get; set; }
    private readonly IReadOnlyList<DateTime> _allowedDate;
    private readonly IReadOnlyList<double> _allowedPrice;
    private Random _random;

    public ProductService()
    {
        _random = new Random();
        _products = new List<Product>();
        _allowedDate = new List<DateTime>() { DateTime.Now, DateTime.Now.AddDays(-1) }.AsReadOnly();
        _allowedPrice = new List<double>() { 2000, 2100, 2200, 2300, 2400, 2500, 2600, 2700, 2800, 2900, 3000 };
    }


    public ProductService GenerateRandomProducts(int collectionCount)
    {
        for (int i = 1; i <= collectionCount; i++)
        {
            var product = GetRandomProductData();
            _products.Add(product);
            // store in radis or something else ??
        }
        return this;
    }

    public IEnumerable<Product> GetProducts() =>
        _products;
    
    private Product GetRandomProductData()
    {
        int randomProductNum = 0;
        DateTime randomDate;
        double randomPrice;
        do
        {
            randomProductNum = _random.Next(1, 10000);
            var randomDateNum = _random.Next(_allowedDate.Count);
            randomDate = _allowedDate[randomDateNum];

            var randomPriceNum = _random.Next(_allowedPrice.Count);
            randomPrice = _allowedPrice[randomPriceNum];

        } while (_products.Any(p => p.Name == $"Product_{randomProductNum}" && p.FetchDate.Day == randomDate.Day));

        return new Product { EntityId = Guid.NewGuid(), Name = $"Product_{randomProductNum}", FetchDate = randomDate, Description = "", Price = randomPrice };
    }
}

