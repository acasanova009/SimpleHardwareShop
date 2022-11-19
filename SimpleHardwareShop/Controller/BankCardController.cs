using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
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

namespace SimpleHardwareShop.Controller
{
    /// <summary>Controlador para  BankCardController,
    /// permite realizar operaciones basicas CRUD</summary>
    public class BankCardController
    {

        public HardwareShopContext _db { get; set; }

        public BankCardController(HardwareShopContext db)
        {
            _db=db;

        }
        public int Create(BankCard bankCard)
        {

            var trackingEntity = _db.BankCards.Add(bankCard);
                _db.SaveChanges();
                              


            return trackingEntity.Entity.Id;


        }

        public List<BankCard> Index(int applicationUserId)
        {
            var adresses = _db.BankCards
                .Where(s => s.CustomerUserId == applicationUserId)
                .ToList();
            return adresses;

            


        }

        

    }
}
