
using SimpleHardwareShop.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Xml.Linq;

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
    /// <summary>Modelo-Entidad para Shopping Cart</summary>
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Count { get; set; }

        public int CustomerUserId { get; set; }
        public CustomerUser? CustomerUser { get; set; }

        public override string ToString()
        {

            
            string? moreProductThanAvailabe = null;
            if (Product?.Stock < Count)
            {
                moreProductThanAvailabe = $"Error: Cantidad de producot disponble es {Product.Stock}, y en el cartito se tiene {Count}";
            }

            return $"[Item]: Id:{Utlierias.E(ProductId.ToString(), 3)}  {Utlierias.R(Product?.Name??"", 20)}                Amount:{Utlierias.E(Count.ToString(), 3)} * ${Utlierias.E(Product?.Price.ToString(), 7)} = ${Utlierias.E((Count * Product?.Price).ToString(), 8)} {moreProductThanAvailabe}";
            
        }

        public string ToStringCompraExitosa()
        {

            

            return $"[Item]: Id:{Utlierias.E(ProductId.ToString(), 3)}  {Utlierias.R(Product?.Name ?? "", 20)}              Amount:{Utlierias.E(Count.ToString(), 3)} * ${Utlierias.E(Product?.Price.ToString(), 7)} = ${Utlierias.E((Count * Product?.Price).ToString(), 8)} ..............Tienda origen:{Product?.RetailShop} ";
            
        }
    }
}
