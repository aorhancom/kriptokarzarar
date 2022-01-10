using BinanceKarZarar;
using Microsoft.AspNetCore.Mvc;
using BinanceKarZarar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BinanceKarZarar.Auth
{
    public class AuthLoginController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));

            if (userId == 0)
                return View();
            else return RedirectToAction("Index", "Anasayfa");
        }

        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {
            using (var db = new BinanceKarZararDbContext())
            {
                var dbUser = db.Users
                               .FirstOrDefault(user => user.Username == loginModel.Username && user.Password == loginModel.Password);

                if (dbUser == null)
                    return View();


                HttpContext.Session.SetInt32("id", dbUser.Id);
                HttpContext.Session.SetString("name", dbUser.Username);
                HttpContext.Session.SetString("yetki", dbUser.Yetki);
                //HttpContext.Session.SetString("apiKey", dbUser.ApiKey);
                //HttpContext.Session.SetString("apiSecretKey", dbUser.ApiSecretKey);

                return RedirectToAction("Index", "Anasayfa");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.SetInt32("id", 0);
            HttpContext.Session.SetString("name", "");

            return RedirectToAction("Index", "Anasayfa");
        }



    }
}
