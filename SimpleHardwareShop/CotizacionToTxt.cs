using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
