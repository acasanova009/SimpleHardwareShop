
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }

        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return "OrderDetail: " + " OrderId:" + OrderHeaderId + " Product:" + Product + " Count:" + Count + " Price:" + Price;
        }
        public string ToStringComprasAnteriores()
        {
            return "OrderDetail:  Product:" + Product.Name + " Count:" + Count + " Price:$ " + Price;
        }

        //public string ToStringReporteVentas
        public static OrderDetail Create(int orderHeaderId, int productId, int count, double price)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                OrderHeaderId=orderHeaderId,
                ProductId=  productId,
                Count= count,
                Price= price
            };
            return orderDetail;
        
        }

    }
}
