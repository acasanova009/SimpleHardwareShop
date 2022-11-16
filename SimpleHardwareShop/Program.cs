// See https://aka.ms/new-console-template for more information
using SimpleHardwareShop;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Data.Loader;
using SimpleHardwareShop.Models;





var db = new HardwareShopContext();

Console.WriteLine($"Database path: {db.DbPath}");

Console.WriteLine("Proyecto Final");
Console.WriteLine("Programación Orientada a Objetos");
Console.WriteLine("Grupo: 9");
Console.WriteLine("Semestre: 3");
Console.WriteLine("Equipo: Individual - Alfonso");
Console.WriteLine("Alfonso Gonzalez Casanova Gallegos");


#if LoadInitialData
DataLoader.Load(db);
#endif

//DataLoader.LoadOrdersHeaderAndDetails( db );    

InteractiveAuthenticationView.Menu(db);





