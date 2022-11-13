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

namespace SimpleHardwareShop.Controller
{
    public class CotizacionDetailController
    {

        public HardwareShopContext _db { get; set; }

        public CotizacionDetailController(HardwareShopContext db)
        {
            _db=db;

        }

        public List<CotizacionDetail> Index()
        {
            return _db.CotizacionDetails.ToList();

        }

        public List<CotizacionDetail> Index(int customerid)
        {


            return _db.CotizacionDetails
                                .Where(e => e.CustomerUserId == customerid)
                                .Where(e => e.YaSeEnvioAlCliente == false)
                                .ToList();
           


           





        }


        public void CreateDetails(CotizacionDetail od)
        {

            if (od != null)
            {
                _db.CotizacionDetails.Add(od);

               
            }

            

        }
        public  void  Save()
        {
             _db.SaveChanges();
        }



        

    }
}
