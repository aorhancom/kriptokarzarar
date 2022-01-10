using BinanceKarZarar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar.Ayarlar
{
    public class AyarlarController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new BinanceKarZararDbContext())
            {
                var dbUser = db.Users.FirstOrDefault(user => user.Id == HttpContext.Session.GetInt32("id"));

                RegisterModel registerModel = new RegisterModel()
                {
                    Username = dbUser.Username,
                    Email = dbUser.Email,
                };


                return View(registerModel);

            }
        }


        [HttpPost]
        public IActionResult Index(RegisterModel registerModel)
        {
            using (var db = new BinanceKarZararDbContext())
            {
                var dbUser = db.Users.FirstOrDefault(user => user.Username == registerModel.Username);
                if (dbUser == null)
                    return BadRequest("Error");

                dbUser.Password = registerModel.Password;
                db.SaveChanges();
                return View(registerModel);
            }

        }
    }
}
