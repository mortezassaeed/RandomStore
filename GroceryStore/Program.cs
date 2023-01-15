
using GroceryStore;

List<Product> productList = new ProductService().GenerateRandomProducts(10000).GetProducts().ToList();

var gpByNameAndPrice = productList
    //.Where(p => p.FetchDate <= DateTime.Now && p.FetchDate >= DateTime.Now.AddDays(-1))
    .GroupBy(e => new { e.Name, e.Price }).Select(g => new { g.Key.Name, g.Key.Price, ProductCount = g.Count() }).ToList();


var withoutChangeProducts = gpByNameAndPrice.Where(p => p.ProductCount == 2).ToList();

var gpByNameAfterGpByNameAndPrice = gpByNameAndPrice.GroupBy(p => new { p.Name }).Select(g => new { g.Key.Name, ProductCount = g.Count() }).ToList();


//(1)
var changedPrice = gpByNameAfterGpByNameAndPrice.Where(p => p.ProductCount == 2).ToList();

var newOrRemovedProduct = gpByNameAfterGpByNameAndPrice.Where(p => p.ProductCount == 1).ToList();

//(2)
var removedProduct = productList.Where(p => newOrRemovedProduct.Select(nr => nr.Name).Contains(p.Name) && p.FetchDate.Day == DateTime.Now.AddDays(-1).Day).ToList(); //TODO : not perfect. needed more effort

//(3)
var newProduct = productList.Where(p => newOrRemovedProduct.Select(nr => nr.Name).Contains(p.Name) && p.FetchDate.Day == DateTime.Now.Day).ToList(); //TODO : not perfect. needed more effort


Console.ReadLine();


/*
    productname - price - count        


   first group by posible data 
        p1 - 200 - 2
        p2 - 300 - 1
        p2 - 400 - 1


    after second group by 

   A = p2 - [] - 2 
    

        => without change
   A => p2 100 1
        p2 200 1
        => changed 
   A => p3 100 (for yesterday)
        => removed
   A => p4 500 (for today)
        => new
 */