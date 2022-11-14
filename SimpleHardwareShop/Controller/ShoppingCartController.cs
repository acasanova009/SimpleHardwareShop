using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Controller
{
    public class ShoppingCartController
    {

        public HardwareShopContext _db { get; set; }

        public ShoppingCartController(HardwareShopContext db)
        {
            _db=db;

        }

        public List<ShoppingCart>?  Index(int applicationUserId)
        {
            var shoppingCarts = _db.ShoppingCarts
                .Include(p => p.Product)
                .Where(s => s.CustomerUserId == applicationUserId)
                .ToList();

            return shoppingCarts;



        }

        public bool VerifyAvailableContents(int applicationUserId)
        {
            var shoopingCartReadyToProceedToPurchase = true;
            var shoppingCarts = _db.ShoppingCarts
               .Include(p => p.Product)
               .Where(s => s.CustomerUserId == applicationUserId)
               .ToList();


            //shoppingCarts.ForEach(s => Console.WriteLine(s));

            foreach (var item in shoppingCarts)
            {
                if(item.Product?.Stock < item.Count)
                {
                    shoopingCartReadyToProceedToPurchase = false;

                }
            }

            if (shoppingCarts.Count==0)
            {
                shoopingCartReadyToProceedToPurchase = false;
            }

            return shoopingCartReadyToProceedToPurchase;
        }
        public void Upsert(int productId, int applicationUserId,int cantidadFinal = 1)
        {
            if (cantidadFinal<0) cantidadFinal=0;
            

            
            var shoppingCart = _db.ShoppingCarts
                .Where(s => s.CustomerUserId == applicationUserId)
                .Where(s=>s.ProductId==productId)
                .FirstOrDefault();

            if (shoppingCart is object)
            {
                //Ya existe el producto, solo hay que definir la cantidad total.
                if (cantidadFinal == 0)
                {
                    //Quiere eliminar el producto del carrito.
                    
                    _db.ShoppingCarts.Remove(shoppingCart);
                    _db.SaveChanges();
                }
                else
                {   
                    //Quiere actualizer el total de producto.

                    shoppingCart.Count = cantidadFinal;
                    _db.ShoppingCarts.Update(shoppingCart);
                    _db.SaveChanges();
                }

            }
            else
            {
                if (cantidadFinal == 0)
                {
                    //Se comete error al ingresar infor de cantidad.

                    return;
                }
                //Es produto nuevo en el carrito.Nueva entrada.
                var product = _db.Products.Find(productId)!;

                shoppingCart = new ShoppingCart()
                {
                    CustomerUserId = applicationUserId,
                    //ProductId = productId,
                    Product = product,
                    Count = cantidadFinal
                };
                _db.ShoppingCarts.Add(shoppingCart);
                _db.SaveChanges();
            }



        }

        public void Remove( int applicationUserId)
        {
            var shoppingCarts = _db.ShoppingCarts.Where(p=>p.CustomerUserId ==applicationUserId);

            _db.ShoppingCarts.RemoveRange(shoppingCarts);
            _db.SaveChanges();

        }

        public void Update(int oldUserId, int newUserId)
        {
            var shoppingCartItems = _db.ShoppingCarts.Where(a => a.CustomerUserId == oldUserId).ToList();

            foreach (var item in shoppingCartItems)
            {
                item.CustomerUserId = newUserId;

            }
            _db.UpdateRange(shoppingCartItems);
            _db.SaveChanges();
        }





        }
}
