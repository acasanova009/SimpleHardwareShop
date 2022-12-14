using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
  Equipo Individual
*/
/*

  Codigo por: Gonzalez Casanova Gallegos Renato Alfonso
  

  Fecha de cración: 19/Nov/2022

  Comentario General: Este programa simula una tienda de productos de hardware, que se conecta directamente con bases de datos.

*/


namespace SimpleHardwareShop.Data.Loader
{
    public static class DataLoader
    {
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
                OrderDate =  new DateTime(2022, 09, 01),

                



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
                CustomerUserId = 2,
                OrderTotal = 4 * 5399 + 2 * 3650,
                DeliveryAdressId = 1,

                OrderDate = new DateTime(2022, 11, 15),



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

            //SECOND
            db.Add(new OrderHeader
            {
                //OrderHeader id = 3 dont uncomment
                CustomerUserId = 3,
                OrderTotal = 4 * 3599 + 2 * 17999,
                DeliveryAdressId = 1,

                OrderDate = new DateTime(2022, 11, 15),



            });
            db.SaveChanges();

            db.Add(new OrderDetail
            {
                OrderHeaderId = 3,
                ProductId = 11,
                Count = 4,
                Price = 3599,


            });

            db.Add(new OrderDetail
            {
                OrderHeaderId = 3,
                ProductId = 12,
                Count = 2,
                Price = 17999,


            });

            //SECOND
            db.Add(new OrderHeader
            {
                //OrderHeader id = 4 dont uncomment
                CustomerUserId = 4,
                OrderTotal =  1* 36999,
                DeliveryAdressId = 1,

                OrderDate = new DateTime(2022, 11, 15),



            });
            db.SaveChanges();

            db.Add(new OrderDetail
            {
                OrderHeaderId = 4,
                ProductId = 16,
                Count = 1,
                Price = 36999,


            });


            db.SaveChanges();


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
                Password = "123456789",

                DefaultBankCardId = 1,
                DefaultDeliveryAdressId = 1,

                DefaultFiscalAdressId = 1,


            });

            db.Add(new CustomerUser
            {
                Name = "Diego",
                LastName = "Hernandez",
                SecondLastName = "Iglesia",
                UserName = "Diego01",
                Email = "diego01@me.com",
                Password = "123456789",

                DefaultBankCardId = 2,
                DefaultDeliveryAdressId = 2,




            });
            db.Add(new CustomerUser
            {
                Name = "Matias",
                LastName = "Castillo",
                SecondLastName = "Barrera",
                UserName = "Matias01",
                Email = "matias01@prodigy.net",
                Password = "123456789",

                DefaultBankCardId = 3,
                DefaultDeliveryAdressId = 3,

                DefaultFiscalAdressId = 1,


            });
            db.Add(new CustomerUser
            {
                Name = "Victoriano",
                LastName = "Tapia",
                SecondLastName = "Cabanillas",
                UserName = "Victoriano01",
                Email = "victoriano01@outlook.com",
                Password = "123456789",

                DefaultBankCardId = 4,
                DefaultDeliveryAdressId = 4,


            });

            db.Add(new CustomerUser
            {
                Name = "Jimena",
                LastName = "Gomez",
                SecondLastName = "Iturribaria",
                UserName = "Jime",
                Email = "jimena007@outlook.com",
                Password = "123456789",

                DefaultBankCardId = 5,
                DefaultDeliveryAdressId = 5,
                DefaultFiscalAdressId = 5,


            });
            //db.Add(new CustomerUser
            //{
            //    Name = "Enique",
            //    LastName = "Flores",
            //    SecondLastName = "Guzman",
            //    UserName = "Kike007",
            //    Email = "kike007@outlook.com",
            //    Password = "123456789",


            //});



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
                Name = "David",
                LastName = "Becker",
                SecondLastName = "Garza",
                UserName = "Dav01",
                Email = "davidDo@hardware.com",
                Password = "123456789",

                RetailShop = RetailShop.PlazaDeLaTecnologia,
                EmployeeType = EmployeeType.Manager,
                EmployeeAdressId = 6,

            });

            db.Add(new EmployeeUser
            {
                Name = "Sebastian",
                LastName = "Ramirez",
                SecondLastName = "Cruz",
                UserName = "Seb01",
                Email = "Sebastian0707@outlook.com",
                Password = "123456789",

                RetailShop = RetailShop.PlazaDeLaTecnologia,
                EmployeeType = EmployeeType.Employee,
                EmployeeAdressId = 7,



            });
            



            db.Add(new EmployeeUser
            {
                Name = "Kevin",
                LastName = "Blanton",
                SecondLastName = "Perez",
                UserName = "Kevin47",
                Email = "kevin@outlook.com",
                Password = "123456789",

                RetailShop = RetailShop.PlazaDeLaTecnologia,
                EmployeeType = EmployeeType.Employee,
                EmployeeAdressId = 8,



            });

            db.Add(new EmployeeUser
            {
                Name = "Gabriel",
                LastName = "Flores",
                SecondLastName = "Sanchez",
                UserName = "Gabriel00014",
                Email = "Flores@hardware.com",
                Password = "123456789",

                RetailShop = RetailShop.Coyoacan,
                EmployeeType = EmployeeType.Manager,
                EmployeeAdressId = 9,


            });

            db.Add(new EmployeeUser
            {
                Name = "Angel",
                LastName = "Ramirez",
                SecondLastName = "Gutierrez",
                UserName = "Angeldd77",
                Email = "Angeldd77@hardware.com",
                Password = "123456789",

                RetailShop = RetailShop.Coyoacan,
                EmployeeType = EmployeeType.Employee,
                EmployeeAdressId = 10,

            });


            db.Add(new EmployeeUser
            {
                Name = "Carlos",
                LastName = "Mendoza",
                SecondLastName = "Aguilar",
                UserName = "Carlos01",
                Email = "Carlos01@hardware.com",
                Password = "123456789",

                RetailShop = RetailShop.Coyoacan,
                EmployeeType = EmployeeType.Employee,
                EmployeeAdressId = 11,


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
                
                CustomerUserId= 1,
                StreetAdress = "Insurgentse 3493",
                PhoneNumber = "55 3409 9347",
                AdditionalInformation = "Enfrente de La Paz",
                PostalCode = 15030,
                RFC = "BGA017084FAS"

            });

            db.Add(new Adress
            {
                
                CustomerUserId = 2,
                StreetAdress = "Copilco 3493",
                PhoneNumber = "55 3409 9347",
                AdditionalInformation = "UNAM",
                PostalCode = 15030,
                RFC = "LEO154891"

            });

            db.Add(new Adress
            {
                CustomerUserId = 3,
                StreetAdress = "Chapultepec 484",
                PhoneNumber = "55 2445 4565",

                PostalCode = 16507,
                RFC = "ASD458945ASF"


            });

            db.Add(new Adress
            {
                CustomerUserId = 4,
                StreetAdress = "Pacifico 484",
                PhoneNumber = "55 4848 5454",

                PostalCode = 14007,
                RFC = "FDF124578SEF"

            });

            db.Add(new Adress
            {
                CustomerUserId = 5,
                StreetAdress = "Ajusco 484",
                PhoneNumber = "5512456598",

                PostalCode = 14007,
                RFC = "FOR124578DDD"

            });

            //Employee adresses.
            db.Add(new Adress
            {
                EmployeeUserId = 6,
                StreetAdress = "Pluton 778",
                PhoneNumber = "54 27785968",

                PostalCode = 13698,
                RFC = "AJA154879FED"


            });

            //Employee adresses.
            db.Add(new Adress
            {
                EmployeeUserId = 7,
                StreetAdress = "Jupiter 444",
                PhoneNumber = "54 22224444",

                PostalCode = 14212,
                RFC = "OKOK123123ASAS"

            });

            //Employee adresses.
            db.Add(new Adress
            {
                EmployeeUserId = 8,
                StreetAdress = "Caracoles 123",
                PhoneNumber = "56 7894 6532",

                PostalCode = 14785,
                RFC = "WEDE457859DFSDF"

            });

            //Employee adresses.
            db.Add(new Adress
            {
                EmployeeUserId = 9,
                StreetAdress = "Pomada 44",
                PhoneNumber = "777 454 6532",

                PostalCode = 0778,
                RFC = "SSD45478986"

            });

            //Employee adresses.
            db.Add(new Adress
            {
                EmployeeUserId = 10,
                StreetAdress = "Albondigas 101",
                PhoneNumber = "998 5748 6542",

                PostalCode = 1100,
                RFC = "GOGR616545ASD"

            });


            //Employee adresses.
            db.Add(new Adress
            {
                EmployeeUserId = 11,
                StreetAdress = "Bermudas 95",
                PhoneNumber = "545 6565 1234",

                PostalCode = 1547,
                RFC = "HHHF4786545"

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
                Name = "Platinum Bancomer",
                CustomerUserId = 1,
                Account = "6659858754823104",
                ExpirationDate = new DateTime(2025, 01, 01),
                SecurityCode = "422"

            });

            db.Add(new BankCard
            {
                Name = "BlackCard A.E.",
                CustomerUserId = 2,
                Account = "4584156418594852",
                ExpirationDate = new DateTime(2027, 01, 01),
                SecurityCode = "987"

            });

            db.Add(new BankCard
            {
                Name = "La Rappi.",
                CustomerUserId = 3,
                Account = "8945625431564854",
                ExpirationDate = new DateTime(2024, 09, 05),
                SecurityCode = "223"


            });
            db.Add(new BankCard
            {
                Name = "Banamex Recompensas.",
                CustomerUserId = 4,
                Account = "5849145625894785",
                ExpirationDate = new DateTime(2024, 09, 05),
                SecurityCode = "223"

            });
            db.Add(new BankCard
            {
                Name = "Tarjeta para emergencias - no usarla.",
                CustomerUserId = 5,
                Account = "1542548795645215",
                ExpirationDate = new DateTime(2024, 09, 05),
                SecurityCode = "223"

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


            db.Add(new ShoppingCart
            {
                ProductId = 15,
                Count = 1,
                CustomerUserId = 4,

            });

            db.Add(new ShoppingCart
            {
                ProductId = 16,
                Count = 1,
                CustomerUserId = 5,

            });

            db.SaveChanges();

        }
    }
}
