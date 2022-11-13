
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
    public class CotizacionDetail
    {
        public int Id { get; set; }
        //[Required]
        public int CustomerUserId { get; set; }
        //public CustomerUser? CustomerUser { get; set; }

        

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public bool YaSeEnvioAlCliente { get; set; }

        //public DateOnly Date { get; set; }

        


        public override string ToString()
        {
            return "CotizacionDetail: " + " Product:" + Product + " Count:" + Count + " Price:" + Price;
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
            };
            return orderDetail;
        
        }

    }
}
