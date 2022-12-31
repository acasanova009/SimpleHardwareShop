
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

namespace SimpleHardwareShop.Models
{
    /// <summary>Modelo-Entidad para CotizacionDetail</summary>
    public class CotizacionDetail
    {
        public int Id { get; set; }
        //[Required]
        public int CustomerUserId { get; set; }
        
        
        public CustomerUser CustomerUser { get; set; }

        

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public bool YaSeEnvioAlCliente { get; set; }

        public DateTime Fecha { get; set; }




        public override string ToString()
        {
            return $"CustomerId: {CustomerUserId} Product:{Product.Name}  Count:{Count} Price: ${Price}..........Fecha: {Fecha}";

        }
        public static CotizacionDetail Create(int userId, int productId, int count, double price)
        {
            CotizacionDetail orderDetail = new CotizacionDetail
            {
                CustomerUserId = userId,
                ProductId = productId,
                Count = count,
                Price = price,
                YaSeEnvioAlCliente = false,
                Fecha = DateTime.Now,
            };
            return orderDetail;
        
        }

    }
}
