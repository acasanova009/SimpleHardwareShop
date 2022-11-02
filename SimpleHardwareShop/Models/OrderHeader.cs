
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
        public int ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public double OrderTotal { get; set; }


        public int DeliveryAdressId { get; set; }
        public Adress DeliveryAdress { get; set; }

        public int? FiscalAdressId { get; set; }
        public Adress? FiscalAdress { get; set; }


        


        public ICollection<OrderDetail>? OrderDetails { get; set; }

        public override string ToString()
        {
            return "ORDER_HEADER: " + " ApplicationUser:" + ApplicationUser + " OrderTotal:" + OrderTotal;
            
        }
    }


    //[Required]
    //public DateTime OrderDate { get; set; }
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

