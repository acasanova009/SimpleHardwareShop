// See https://aka.ms/new-console-template for more information
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Data.Loader;
using SimpleHardwareShop.Models;




var db = HardwareShopContext.Instance();

#if LoadInitialData
DataLoader.Load(db);
#endif

var interactiveView = new InteractiveView(db);
interactiveView.UserMenu();


