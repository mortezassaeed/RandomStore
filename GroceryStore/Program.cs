
using GroceryStore;
using System.Security.Cryptography;

List<Entity> productList = new List<Entity>();


var gpByNameAndPrice = productList
    .Where(p => p.FetchDate <= DateTime.Now && p.FetchDate >= DateTime.Now.AddDays(-1))
    .GroupBy(e => new { e.Name, e.Price }).Select(g => new { g.Key.Name, g.Key.Price, ProductCount = g.Count() });


var withoutChangeProducts = gpByNameAndPrice.Where(p => p.ProductCount == 2);

var gpByNameAfterGpByNameAndPrice = gpByNameAndPrice.GroupBy(p => new { p.Name }).Select(g => new { g.Key.Name, ProductCount = g.Count() });


//(1)
var changedPrice = gpByNameAfterGpByNameAndPrice.Where(p => p.ProductCount == 2);

var newOrRemovedProduct = gpByNameAfterGpByNameAndPrice.Where(p => p.ProductCount == 1);

//(2)
var removedProduct = productList.Where(p => newOrRemovedProduct.Select(nr => nr.Name).Contains(p.Name) && p.FetchDate.Day == DateTime.Now.AddDays(-1).Day); //TODO : not perfect. needed more effort

//(3)
var newProduct = productList.Where(p => newOrRemovedProduct.Select(nr => nr.Name).Contains(p.Name) && p.FetchDate.Day == DateTime.Now.Day); //TODO : not perfect. needed more effort



/*
 
   A = p1 200 2 
        => without change
   A => p2 100 1
        p2 200 1
        => changed 
   A => p3 100 (for yesterday)
        => removed
   A => p4 500 (for today)
        => new

 */






