using System;
using System.Collections.Generic;
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

namespace SimpleHardwareShop
{
    class CotizacionToTxt
    {

        //await CotizacionToTxt.WriteText("a");
        public static async Task WriteText(string nameOfTextFile,string a)
        {
            string text =
                "Cotizacion Final:\n" +
                
                a;

            await File.WriteAllTextAsync($"{nameOfTextFile}.txt", text);
        }
    }

}
