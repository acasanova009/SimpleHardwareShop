using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Data.Loader
{
    public static class DataLoader
    {
        public static void LoadOrdersHeaderAndDetails(HardwareShopContext db)
        {
            /*
            *OrderHeaders with  OrderDetails
            * 
            * 
            * 
            * 
            */

            //Order header id 
            db.Add(new OrderHeader
            {
                //OrderHeader id = 1 dont uncomment
                CustomerUserId = 1,
                OrderTotal = 54045,
                DeliveryAdressId = 1,



            });
            db.SaveChanges();

            db.Add(new OrderDetail
            {
                OrderHeaderId = 1,
                ProductId = 5,
                Count = 4,
                Price = 8999,


            });

            db.Add(new OrderDetail
            {
                OrderHeaderId = 1,
                ProductId = 6,
                Count = 3,
                Price = 350,


            });

            db.Add(new OrderDetail
            {
                OrderHeaderId = 1,
                ProductId = 7,
                Count = 1,
                Price = 16999,


            });

            //SECOND
            db.Add(new OrderHeader
            {
                //OrderHeader id = 2 dont uncomment
                CustomerUserId = 1,
                OrderTotal = 4 * 5399 + 2 * 3650,
                DeliveryAdressId = 1,



            });
            db.SaveChanges();

            db.Add(new OrderDetail
            {
                OrderHeaderId = 2,
                ProductId = 1,
                Count = 4,
                Price = 5399,


            });

            db.Add(new OrderDetail
            {
                OrderHeaderId = 2,
                ProductId = 2,
                Count = 2,
                Price = 3650,


            });

            db.SaveChanges();


        }


        public static void Load(HardwareShopContext db)
        {
            DataLoader.LoadProduct(db);
            DataLoader.LoadCustomers(db);
            DataLoader.LoadEmployess(db);


            //Dependent entries
            DataLoader.LoadShoppingCarts(db);
            DataLoader.LoadAdresses(db);
            DataLoader.LoadBankCards(db);


            //Customer, product, and adress  dependent entities

            DataLoader.LoadOrdersHeaderAndDetails(db);
            
        }

        public static void LoadProduct(HardwareShopContext db)
        {

            /*
            * PRODUCTS
            * 
            * 
            */
            db.Add(new Product
            {
                Name = "Monitor ASUS",
                Description = "Monitor de 24” HDMI, VGA",
                Price = 5399,
                Stock = 15,
                DefaultStock = 15,
                Serie = "AS24001",
                Inventory = "SP01001",
                RetailShop = RetailShop.Coyoacan
            });
            db.Add(new Product
            {
                Name = "Monitor HP",
                Description = "Monitor 21” VGA",
                Price = 3650,
                Stock = 10,
                DefaultStock = 10,
                Serie = "HP21002",
                Inventory = "SP01002",
                RetailShop = RetailShop.Coyoacan
            });
            db.Add(new Product
            {
                Name = "Monitor DELL",
                Description = "Monitor 21” DP",
                Price = 3599,
                Stock = 9,
                DefaultStock = 9,
                Serie = "DE21003",
                Inventory = "SP01003",
                RetailShop = RetailShop.Coyoacan
            });
            db.Add(new Product
            {
                Name = "Laptop Dell",
                Description = "1 TB DD, 8 GB RAM, Intel Core i5",
                Price = 17999,
                Stock = 24,
                DefaultStock = 24,
                Serie = "DEOP001",
                Inventory = "SP01004",
                RetailShop = RetailShop.Coyoacan
            });
            db.Add(new Product
            {
                Name = "iPad",
                Description = "64 GB,10.9Pulgadas",
                Price = 8999,
                Stock = 15,
                DefaultStock = 15,
                Serie = "APG1001",
                Inventory = "SP01005",
                RetailShop = RetailShop.Coyoacan
            });
            db.Add(new Product
            {
                Name = "Combo Teclado Mouse",
                Description = "Logitech K200,negro, USB",
                Price = 350,
                Stock = 22,
                DefaultStock = 22,
                Serie = "LGK2002",
                Inventory = "SP01006",
                RetailShop = RetailShop.Coyoacan
            });
            db.Add(new Product
            {
                Name = "Laptop HP",
                Description = "1 TB DD, 8 GB RAM,AMD Ryzen 5",
                Price = 16999,
                Stock = 6,
                DefaultStock = 6,
                Serie = "HPSP005",
                Inventory = "SP01007",
                RetailShop = RetailShop.Coyoacan
            });
            db.Add(new Product
            {
                Name = "Laptop Alienware",
                Description = "512 SSD, 1 TB DD, 16 GB RAM,Intel Core i7,Nvidia RTX 3050",
                Price = 36999,
                Stock = 11,
                DefaultStock = 11,
                Serie = "DEAW001",
                Inventory = "SP01008",
                RetailShop = RetailShop.Coyoacan
            });

            //Plaza de la tecnologia

            db.Add(new Product
            {
                Name = "Monitor ASUS",
                Description = "Monitor de 24”\r\nHDMI, VGA",
                Price = 5399,
                Stock = 15,
                DefaultStock = 15,
                Serie = "AS24001",
                Inventory = "SP01001",
                RetailShop = RetailShop.PlazaDeLaTecnologia
            });
            db.Add(new Product
            {
                Name = "Monitor HP",
                Description = "Monitor 21” VGA",
                Price = 3650,
                Stock = 10,
                DefaultStock = 10,
                Serie = "HP21002",
                Inventory = "SP01002",
                RetailShop = RetailShop.PlazaDeLaTecnologia
            });
            db.Add(new Product
            {
                Name = "Monitor DELL",
                Description = "Monitor 21” DP",
                Price = 3599,
                Stock = 9,
                DefaultStock = 9,
                Serie = "DE21003",
                Inventory = "SP01003",
                RetailShop = RetailShop.PlazaDeLaTecnologia
            });
            db.Add(new Product
            {
                Name = "Laptop Dell",
                Description = "1 TB DD, 8 GB RAM, Intel Core i5",
                Price = 17999,
                Stock = 24,
                DefaultStock = 24,
                Serie = "DEOP001",
                Inventory = "SP01004",
                RetailShop = RetailShop.PlazaDeLaTecnologia
            });
            db.Add(new Product
            {
                Name = "iPad",
                Description = "64 GB,10.9Pulgadas",
                Price = 8999,
                Stock = 15,
                DefaultStock = 15,
                Serie = "APG1001",
                Inventory = "SP01005",
                RetailShop = RetailShop.PlazaDeLaTecnologia
            });
            db.Add(new Product
            {
                Name = "Combo Teclado Mouse",
                Description = "Logitech K200,negro, USB",
                Price = 350,
                Stock = 22,
                DefaultStock = 22,
                Serie = "LGK2002",
                Inventory = "SP01006",
                RetailShop = RetailShop.PlazaDeLaTecnologia
            });
            db.Add(new Product
            {
                Name = "Laptop HP",
                Description = "1 TB DD, 8 GB RAM,AMD Ryzen 5",
                Price = 16999,
                Stock = 6,
                DefaultStock = 6,
                Serie = "HPSP005",
                Inventory = "SP01007",
                RetailShop = RetailShop.PlazaDeLaTecnologia
            });
            db.Add(new Product
            {
                Name = "Laptop Alienware",
                Description = "512 SSD, 1 TB DD, 16 GB RAM,Intel Core i7,Nvidia RTX 3050",
                Price = 36999,
                Stock = 11,
                DefaultStock = 11,
                Serie = "DEAW001",
                Inventory = "SP01008",
                RetailShop = RetailShop.PlazaDeLaTecnologia
            });


            db.SaveChanges();

        }

        public static void LoadCustomers(HardwareShopContext db)
        {
            db.Add(new CustomerUser
            {
                Name = "Leo",
                LastName = "Herrera",
                SecondLastName = "Garcia",
                UserName = "Leo01",
                Email = "leo@mac.com",
                Password = "123",

                DefaultBankCardId = 1,
                DefaultDeliveryAdressId = 1,


            });

            db.Add(new CustomerUser
            {
                Name = "Diego",
                LastName = "Hernandez",
                SecondLastName = "Iglesia",
                UserName = "Severo01",
                Email = "diego01@me.com",
                Password = "123",
                //UserType = UserType.Application,
                //DeliveryAdressId =10,
                //FiscalAdressId=10


            });
            db.Add(new CustomerUser
            {
                Name = "Matias",
                LastName = "Castillo",
                SecondLastName = "Barrera",
                UserName = "Matias01",
                Email = "matias01@prodigy.net",
                Password = "123",
                //UserType = UserType.Application,
                //DeliveryAdressId =10,
                //FiscalAdressId=10


            });
            db.Add(new CustomerUser
            {
                Name = "Victoriano",
                LastName = "Tapia",
                SecondLastName = "Cabanillas",
                UserName = "Victoriano01",
                Email = "victoriano01@outlook.com",
                Password = "123",
                //UserType = UserType.Application,
                //DeliveryAdressId =10,
                //FiscalAdressId=10


            });

        }

        public static void LoadEmployess(HardwareShopContext db)
        {

            /*
           * Employess
           * 
           * 
           * 
           */

            db.Add(new EmployeeUser
            {
                Name = "Alfonso",
                LastName = "Gonzalez",
                SecondLastName = "Casanova",
                UserName = "Alfonso01",
                Email = "alfonso@hardware.com",
                Password = "123",

                RetailShop = RetailShop.HeadQuarters,
                EmployeeType = EmployeeType.Manager,

                //UserType = UserType.Application,
                //DeliveryAdressId =10,
                //FiscalAdressId=10


            });

            db.Add(new EmployeeUser
            {
                Name = "Pedro",
                LastName = "Gonzalez",
                SecondLastName = "Perez",
                UserName = "Pedro01",
                Email = "pedro01@outlook.com",
                Password = "123",

                RetailShop = RetailShop.PlazaDeLaTecnologia,
                EmployeeType = EmployeeType.Employee,

                //UserType = UserType.Application,
                //DeliveryAdressId =10,
                //FiscalAdressId=10


            });



            db.SaveChanges();
        }

        public static void LoadAdresses(HardwareShopContext db)
        {






            /*
            * ADRESSES
            * 
            * 
            */

            db.Add(new Adress
            {
                CustomerUserId = 1,
                StreetAdress = "Insurgentse 3493",
                PhoneNumber = "55 3409 9347",
                AdditionalInformation = "Enfrente de La Paz",
                PostalCode = 15030,
                RFC = null

            });

            db.Add(new Adress
            {
                CustomerUserId = 1,
                StreetAdress = "Copilco 3493",
                PhoneNumber = "55 3409 9347",
                AdditionalInformation = "UNAM",
                PostalCode = 15030,
                RFC = "LEO154891"

            });

            db.Add(new Adress
            {
                CustomerUserId = 2,
                StreetAdress = "Chapultepec 484",
                PhoneNumber = "55 2445 4565",

                PostalCode = 16507,
                RFC = null

            });

            db.Add(new Adress
            {
                CustomerUserId = 3,
                StreetAdress = "Pacifico 484",
                PhoneNumber = "55 4848 5454",

                PostalCode = 14007,
                RFC = null

            });




            db.SaveChanges();
        }


        public static void LoadBankCards(HardwareShopContext db)
        {

            /*
           * BANK CARDS
           * 
           * 
           */
            db.Add(new BankCard
            {
                Name = "MyFavorite CreditCard",
                CustomerUserId = 1,
                Account = "4565184598654859",
                ExpirationDate = new DateTime(2025, 01, 01),
                SecurityCode = 542

            });

            db.Add(new BankCard
            {
                Name = "BlackCard for big expenses.",
                CustomerUserId = 2,
                Account = "4584156418594852",
                ExpirationDate = new DateTime(2027, 01, 01),
                SecurityCode = 976

            });

            db.Add(new BankCard
            {
                Name = "DigitalCard",
                CustomerUserId = 3,
                Account = "5849145625894785",
                ExpirationDate = new DateTime(2024, 09, 05),
                SecurityCode = 116

            });



            db.SaveChanges();


        }

        public static void LoadShoppingCarts(HardwareShopContext db)
        {

            /*
            * Shopping Car Items
            * 
            * 
            * 
            * 
            */

            db.Add(new ShoppingCart
            {
                ProductId = 5,
                Count = 5,
                CustomerUserId = 1,

            });

            db.Add(new ShoppingCart
            {
                ProductId = 12,
                Count = 5,
                CustomerUserId = 1,

            });
            db.Add(new ShoppingCart
            {
                ProductId = 4,
                Count = 2,
                CustomerUserId = 1,

            });


            db.Add(new ShoppingCart
            {
                ProductId = 13,
                Count = 1,
                CustomerUserId = 2,

            }); db.Add(new ShoppingCart
            {
                ProductId = 16,
                Count = 2,
                CustomerUserId = 2,

            });



            db.Add(new ShoppingCart
            {
                ProductId = 1,
                Count = 1,
                CustomerUserId = 3,

            });
            db.Add(new ShoppingCart
            {
                ProductId = 2,
                Count = 2,
                CustomerUserId = 3,

            });
            db.Add(new ShoppingCart
            {
                ProductId = 3,
                Count = 3,
                CustomerUserId = 3,

            });

            db.Add(new ShoppingCart
            {
                ProductId = 4,
                Count = 4,
                CustomerUserId = 3,

            });


            db.Add(new ShoppingCart
            {
                ProductId = 6,
                Count = 6,
                CustomerUserId = 3,

            });

            db.SaveChanges();

        }
    }
}
