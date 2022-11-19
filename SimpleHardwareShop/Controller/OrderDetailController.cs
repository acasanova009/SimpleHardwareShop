using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


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
        /// <summary>Controlador para OrderDetailController ,
        /// permite realizar operaciones basicas CRUD</summary>
    public class OrderDetailController
    {

        public HardwareShopContext _db { get; set; }

        public OrderDetailController(HardwareShopContext db)
        {
            _db=db;

        }
        public List<OrderDetail> Index()
        {
            return _db.OrderDetails.Include(e=>e.Product).ToList();





        }

        public List<OrderDetail> IndexByProduct(int productId)
        {
            return _db.OrderDetails.Where(a=>a.ProductId==productId).ToList();


        }

        public List<OrderDetail> IndexByShop(RetailShop retailShop)
        {
            return _db.OrderDetails
                    .Include(a=>a.Product)
                    .Where(a=>a.Product.RetailShop==retailShop)
                    .ToList();


        }




    }
}
