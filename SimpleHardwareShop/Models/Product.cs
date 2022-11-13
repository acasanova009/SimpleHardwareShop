using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHardwareShop.Models;

namespace SimpleHardwareShop.Models
{
    public class Product
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Stock { get; set; }

        public double DefaultStock { get; set; }

        public string Serie { get; set; }

        public string Inventory { get; set; }

        public RetailShop RetailShop { get; set; }

        public override string ToString()
        {

            //return "PRODUCT: " + " Id: " + Id+ Name + " Price:" + Price + " Stock:" + Stock + " RetailShop:" + RetailShop + " Serie:" + Serie;
            return $"[Producto]: Id:{Id} ${Price} Tienda: {RetailShop}  Stock:{Stock}/{DefaultStock} ******* {Name} ------------------Detalles: {Description} ";
            //return "PRODUCT " + "Name: " + Name ;
        }

        public string ToStringMin()
        {
            return $"[Producto]: Id:{Id} ${Price} Tienda: {RetailShop}   {Name}";
        }


    }
}
