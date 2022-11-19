using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
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

namespace SimpleHardwareShop.Controller
{
        /// <summary>Controlador para  ProductController,
        /// permite realizar operaciones basicas CRUD</summary>
    public class ProductController
    {

        public HardwareShopContext _db { get; set; }

        public ProductController(HardwareShopContext db)
        {
            _db=db;

        }

        public List<Product>  Index(string? textFilter = null)
        {
            List<Product>? products = null;
            if (textFilter == null)
            {

                products =  _db.Products.Where(p =>
                p.Stock > 0).ToList();
                return products;
            }
            else
            {
                products = _db.Products.Where(p =>
                 
                p.Name.Contains(textFilter) ||
                p.Description.Contains(textFilter) ||
                p.Serie.Contains(textFilter) ||
                p.Inventory.Contains(textFilter) ||
                p.Price.ToString().Contains(textFilter) 

                ).ToList();
                //products.ForEach(p => Console.WriteLine(p));
                return products;

            }

            //return products;

        }

        public void Update()
        {
            var products = _db.Products.ToList();
            foreach (var product in products)
            {
                product.Stock = product.DefaultStock;


            }   
            _db.UpdateRange(products);


        }
        
        public void Update(ShoppingCart shoppingCartItem)
        {
            

            var products = _db.Products.Where(a=>a.Id==shoppingCartItem.ProductId).ToList();

            foreach (var product in products)
            {
                product.Stock -= shoppingCartItem.Count;


            }
            _db.UpdateRange(products);
        }



        

    }
}
