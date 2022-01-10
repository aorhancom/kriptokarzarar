using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar.AdminPanel
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new BinanceKarZararDbContext ())
            {
                var dbUser = db.Users.FirstOrDefault(user => user.Id == HttpContext.Session.GetInt32("id"));
                if (dbUser.Yetki.ToLower() == "admin")
                {
                    var users = db.Users.ToList();
                    return View(users);
                }
                else
                {
                    return RedirectToAction("Index", "Anasayfa");
                }
            }
           
        }
    }
}
