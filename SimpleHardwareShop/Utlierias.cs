using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// <summary>Class <c>Utlierias</c> Ayuda a generar una vista legible del texto en consola.</summary>
    ///
    static class Utlierias
    {

        public static string Enlarge(string? a, int size)
        {
            a ??= "";
            var additional = "";
            var left =  size - a.Length;
            for (int i = 0; i < left; i++)
            {
                additional+= " ";
            }
            return additional + a;

        }
        public static string E(string? a, int size)
        {
            return Enlarge(a, size);
        }

        public static string EnlargeR(string? a, int size)
        {
            a ??= "";
            var additional = "";
            var left = size - a.Length;
            for (int i = 0; i < left; i++)
            {
                additional += " ";
            }
            return  a + additional;

        }
        public static string R(string? a, int size)
        {
            return EnlargeR(a, size);
        }

    }
}
