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
        /// <summary>Controlador para  OrderHeaderController
        /// permite realizar operaciones basicas CRUD</summary>
    public class OrderHeaderController
    {

        public HardwareShopContext _db { get; set; }

        public OrderHeaderController(HardwareShopContext db)
        {
            _db=db;

        }
        public List<OrderHeader> Index(int userId)
        {
            var includableQueryable = _db.OrderHeaders
                                .Where(e => e.CustomerUserId == userId)
                                .Include(e => e.OrderDetails);
                                

            var orders = includableQueryable
                    .ThenInclude(m => m.Product).AsNoTracking().ToList();
           

            return orders;


        }

        public int Create(OrderHeader oh)
        {
            
            var trackingEntity= _db.OrderHeaders.Add(oh);

            _db.SaveChanges();

            return trackingEntity.Entity.Id;  
            
        }

        public void CreateDetails(OrderDetail od)
        {

            if (od != null)
            {
                _db.OrderDetails.Add(od);
                _db.SaveChanges();


            }

            

        }
       


        

    }
}
