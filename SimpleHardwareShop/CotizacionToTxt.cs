﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop
{
    class CotizacionToTxt
    {

        //await CotizacionToTxt.WriteText("a");
        public static async Task WriteText(string a)
        {
            string text =
                "A class is the most powerful data type in C#. Like a structure, " +
                "a class defines the data and behavior of the data type. ";

            await File.WriteAllTextAsync("WriteText.txt", text);
        }
    }

}