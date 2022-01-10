using BinanceKarZarar.Entities;
using BinanceKarZarar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar.Auth
{
    public class AuthRegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterModel registerModel)
        {
            using (var db=new BinanceKarZararDbContext())
            {
                var dbUser = db.Users.FirstOrDefault(user => user.Email == registerModel.Email || user.Username == registerModel.Username);
                if (dbUser != null)
                    return View();

                var user = new User()
                {
                    Username = registerModel.Username,
                    Email = registerModel.Email,
                    Password = registerModel.Password,
                    Yetki = "user",
                    ApiKey = "",
                    ApiSecretKey = "",


                };

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "AuthLogin");
            }

        }
    }
}
