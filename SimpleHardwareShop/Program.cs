// See https://aka.ms/new-console-template for more information
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;




var db = new HardwareShopContext();

#if LoadInitialData
    
#endif

Console.WriteLine("Inserting a new Product");

db.Add(new Product {
    Name = "AnotherLapropasdasdasdasd",
    Description = "Dungel",
    Price = 5.5,
    Stock=5,
    Serie="as",
    Inventory="aaaaa",
    RetailShop = RetailShop.Galerias
});
db.Add(new Product
{
    Name = "AnotherLaprop",
    Description = "Dungel",
    Price = 5.5,
    Stock = 5,
    Serie = "as",
    Inventory = "aaaaa",
    RetailShop = RetailShop.PlazaDeLaComputacion
});

db.SaveChanges();

//var interactiveView = new InteractiveView(db);

//interactiveView.UserMenu();



//var product1 = new Product()
//{
//    Name = "Laptop",
//    Description = "Dungel",
//    Price = 5.5
//};

//db.Products.Add(product1);

//db.SaveChanges();

