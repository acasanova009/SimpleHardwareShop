
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

        public int CustomerUserId { get; set; }
        public CustomerUser? CustomerUser { get; set; }

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

            return $"[Item]: Id:{Utlierias.E(ProductId.ToString(), 3)}  {Utlierias.R(Product?.Name??"", 20)}                Amount:{Utlierias.E(Count.ToString(), 3)} * ${Utlierias.E(Product?.Price.ToString(), 7)} = ${Utlierias.E((Count * Product?.Price).ToString(), 8)} {moreProductThanAvailabe}";
            //return $"[Producto]: Id:{Utlierias.E(Id.ToString(), 3)} ${Utlierias.E(Price.ToString(), 7)} Tienda: {Utlierias.R(RetailShop.ToString(), 20)}  Stock:{Utlierias.E(Stock.ToString(), 3)}/{Utlierias.E(DefaultStock.ToString(), 3)} ** {Utlierias.R(Name, 20)} Detalles: {Utlierias.R(Description, 100)} ";
            //return "PRODUCT " + "Name: " + Name ;
        }

        public string ToStringCompraExitosa()
        {

            //return "PRODUCT: " + " Id: " + Id+ Name + " Price:" + Price + " Stock:" + Stock + " RetailShop:" + RetailShop + " Serie:" + Serie;

            return $"[Item]: Id:{Utlierias.E(ProductId.ToString(), 3)}  {Utlierias.R(Product?.Name ?? "", 20)}              Amount:{Utlierias.E(Count.ToString(), 3)} * ${Utlierias.E(Product?.Price.ToString(), 7)} = ${Utlierias.E((Count * Product?.Price).ToString(), 8)} ..............Tienda origen:{Product?.RetailShop} ";
            //return $"[Item]: Id:{ProductId}  {Product?.Name}:     Amount:{Count} * ${Product?.Price} =                                   ${Count * Product?.Price} ";
            //return "PRODUCT " + "Name: " + Name ;
        }
    }
}
