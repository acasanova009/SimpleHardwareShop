
using SimpleHardwareShop.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Xml.Linq;


namespace SimpleHardwareShop.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Count { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        //[NotMapped]
        //public double Price { get; set; }

        public override string ToString()
        {

            //return "PRODUCT: " + " Id: " + Id+ Name + " Price:" + Price + " Stock:" + Stock + " RetailShop:" + RetailShop + " Serie:" + Serie;
            string? moreProductThanAvailabe = null;
            if (Product?.Stock < Count)
            {
                moreProductThanAvailabe = $"Error: Cantidad de producot disponble es {Product.Stock}, y en el cartito se tiene {Count}";
            }

            return $"[Item]: Id:{ProductId}  {Product?.Name}:     Amount:{Count} * ${Product?.Price} =                                   ${Count*Product?.Price} {moreProductThanAvailabe}";
            //return "PRODUCT " + "Name: " + Name ;
        }
    }
}
