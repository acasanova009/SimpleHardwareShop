﻿using Microsoft.EntityFrameworkCore;
using SimpleHardwareShop.Data;
using SimpleHardwareShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHardwareShop.Controller
{
    public class AdressController
    {

        public HardwareShopContext _db { get; set; }

        public AdressController(HardwareShopContext db)
        {
            _db=db;

        }
        public int Create(Adress adress)
        {

            var trackingEntity =  _db.Adresses.Add(adress);
                _db.SaveChanges();


            return trackingEntity.Entity.Id;

        }

        public void Remove(Adress adress)
        {
            _db.Remove(adress);
            _db.SaveChanges();
        }

        public List<Adress> Index(int applicationUserId)
        {
            var addresse  = _db.Adresses.Where(s => s.CustomerUserId == applicationUserId).ToList();
            return addresse;

            


        }

        public List<Adress> IndexEmployee(int applicationUserId)
        {
            var addresse = _db.Adresses.Where(s => s.EmployeeUserId == applicationUserId).ToList();
            return addresse;




        }
        public Adress Read(int userId, int adressId)
        {
            return  _db.Adresses
                .Where(s => s.CustomerUserId == userId)
                .Where(s => s.Id == adressId)
                .Single();

        }



    }
}
