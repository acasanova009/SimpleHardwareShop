﻿// See https://aka.ms/new-console-template for more information
using SimpleHardwareShop;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Data.Loader;
using SimpleHardwareShop.Models;
using SimpleHardwareShop.Views;


/// <summary>Class <c>Program</c> Permite al programa inciciar, y manda a llamar la base de datos, y la visita iniicial.</summary>

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Proyecto Final");
        Console.WriteLine("Programación Orientada a Objetos");
        Console.WriteLine("Grupo: 9");
        Console.WriteLine("Semestre: 3");
        Console.WriteLine("Equipo: Individual - Alfonso");
        Console.WriteLine("Alfonso Gonzalez Casanova Gallegos");


        var db = new HardwareShopContext();
#if !LoadInitialData
        //DataLoader.Load(db);

#endif
 



        InteractiveAuthenticationView.Menu(db);
    }
}