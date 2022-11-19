using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


/* 
  Equipo Individual
*/
/*

  Codigo por: Gonzalez Casanova Gallegos Renato Alfonso
  

  Fecha de cración: 19/Nov/2022

  Comentario General: Este programa simula una tienda de productos de hardware, que se conecta directamente con bases de datos.

*/

namespace SimpleHardwareShop.Controller
{
    /// <summary>Controlador para  CotizacionDetailController,
    /// permite realizar operaciones basicas CRUD</summary>
    public class CotizacionDetailController
    {

        public HardwareShopContext _db { get; set; }

        public CotizacionDetailController(HardwareShopContext db)
        {
            _db=db;

        }

        public List<CotizacionDetail> Index()
        {
            return _db.CotizacionDetails
                //.Where(e => e.YaSeEnvioAlCliente == false)
                .Include(a=>a.Product)
                .Include(a => a.CustomerUser)
                .ToList();

        }

        public List<CotizacionDetail> Index(int customerid)
        {


            return _db.CotizacionDetails
                                .Where(e => e.CustomerUserId == customerid)
                                .Where(e => e.YaSeEnvioAlCliente == false)
                                .Include(a => a.Product)
                                .Include(a => a.CustomerUser)
                                .ToList();
           


           





        }

        public void Update(int customerid)
        {
            var cotizaciones = _db.CotizacionDetails
                                .Where(e => e.CustomerUserId == customerid)
                                .Where(e => e.YaSeEnvioAlCliente == false)
                                //.Include(a => a.Product)
                                //.Include(a => a.CustomerUser)
                                .ToList();
            foreach (var cot in cotizaciones)
            {
                cot.YaSeEnvioAlCliente= true;


            }
            _db.CotizacionDetails.UpdateRange(cotizaciones);    
            _db.SaveChanges();

        }

        public void Create(CotizacionDetail od)
        {

            if (od != null)
            {
                _db.CotizacionDetails.Add(od);

                _db.SaveChanges();
               
            }

            

        }
        //public  void  Save()
        //{
        //}



        

    }
}
