
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public int? CustomerUserId { get; set; }
        public CustomerUser? CustomerUser { get; set; }
        public double OrderTotal { get; set; }


        public int DeliveryAdressId { get; set; }
        public Adress? DeliveryAdress { get; set; }

        public int? FiscalAdressId { get; set; }
        public Adress? FiscalAdress { get; set; }

        
        public DateTime OrderDate { get; set; }


        

        
        public ICollection<OrderDetail>? OrderDetails { get; set; }

        public override string ToString()
        {
           var top = $"Orden: {Id}";
            if(OrderDetails != null)
            foreach (var orderDetail in OrderDetails)
            {
                    top += $"\n {orderDetail.ToStringComprasAnteriores()}";

            }
            top += $"\n  Total:............. ${OrderTotal}";
       

            return top;
            
        }

        //public OrderHeader(int userId, double orderTotal, int deliveryAdress, int? fiscalAdress)
        //{
        //    //var orderHeader = new OrderHeader
        //    //{
        //    ApplicationUserId = userId;
        //    OrderTotal = orderTotal;
        //    DeliveryAdressId = deliveryAdress;
        //    FiscalAdressId = fiscalAdress;



        //    //};

        //    //return orderHeader;
        //}

        public static OrderHeader Create(int userId, double orderTotal, int deliveryAdress, int? fiscalAdress)
        {
            var orderHeader = new OrderHeader
            {
                CustomerUserId = userId,
                OrderTotal = orderTotal,
                DeliveryAdressId = deliveryAdress,
                FiscalAdressId = fiscalAdress,
                OrderDate= DateTime.Now,



            };

            return orderHeader;
        }
    }


    //[Required]

    //public DateTime ExpirationDate { get; set; }
    //public DateTime ShippingDate { get; set; }
    //public string? OrderStatus { get; set; }
    //public string? PaymentStatus { get; set; }
    //public string? TrackingNumber { get; set; }
    //public string? Carrier { get; set; }
    //public DateTime PaymentDate { get; set; }
    //public DateTime PaymentDueDate { get; set; }

    //public string? SessionId { get; set; }
    //public string? PaymentIntentId { get; set; }*/


}

