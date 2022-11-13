﻿// See https://aka.ms/new-console-template for more information
using SimpleHardwareShop;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Data.Loader;
using SimpleHardwareShop.Models;





var db = new HardwareShopContext();

Console.WriteLine($"Database path: {db.DbPath}");

#if LoadInitialData
DataLoader.Load(db);
#endif

//DataLoader.LoadOrdersHeaderAndDetails( db );    

InteractiveAuthenticationView.Menu(db);





