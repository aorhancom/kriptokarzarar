using BinanceKarZarar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar.ApiEkle
{
    public class ApiEkleController : Controller
    {   
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new BinanceKarZararDbContext())
            {
                var dbUser = db.Users.FirstOrDefault(user => user.Id == HttpContext.Session.GetInt32("id"));

                BinanceKeyModel binanceKey = new BinanceKeyModel()
                {
                    ApiKey = dbUser.ApiKey,
                    ApiSecretKey = dbUser.ApiSecretKey,
                };


                return View(binanceKey);

            }
            
        }

        [HttpPost]
        public IActionResult Index(BinanceKeyModel binanceKeyModel)
        {
            using (var db = new BinanceKarZararDbContext())
            {
                var dbUser = db.Users.FirstOrDefault(user => user.Id == HttpContext.Session.GetInt32("id"));

                dbUser.ApiKey = binanceKeyModel.ApiKey;
                dbUser.ApiSecretKey = binanceKeyModel.ApiSecretKey;
                db.SaveChanges();
            }

            return View(binanceKeyModel);
        }
    }
}
