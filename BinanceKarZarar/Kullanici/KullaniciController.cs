using BinanceKarZarar.Entities;
using BinanceKarZarar.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar.Kullanici
{
    public class KullaniciController : Controller
    {
        //[Route("Kullanici/{id:int}")]
        public ActionResult Index(int id)
        {
            try
            {
                using (var db = new BinanceKarZararDbContext())
                {
                    var dbUser = db.Users.FirstOrDefault(u => u.Id == id);
                    var _user = new UserEditModel()
                    {
                        Email = dbUser.Email,
                        Password = dbUser.Password,
                        Username = dbUser.Username,
                        Id = dbUser.Id.ToString()
                    };
                    return View(_user);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: KullaniciController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KullaniciController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KullaniciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KullaniciController/Edit/5
        [HttpPost]
        public ActionResult Edit(UserEditModel userEditModel)
        {
            try
            {
                using (var db = new BinanceKarZararDbContext())
                {
                    var dbUser = db.Users.FirstOrDefault(u => u.Id == Convert.ToInt32(userEditModel.Id));

                    dbUser.Email = userEditModel.Email;
                    dbUser.Password = userEditModel.Password;
                    dbUser.Username = userEditModel.Username;

                    db.SaveChanges();

                    return Redirect("Index/" + dbUser.Id);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        //// POST: KullaniciController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: KullaniciController/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new BinanceKarZararDbContext())
            {
                var dbUser = db.Users.FirstOrDefault(u => u.Id == id);

                if (dbUser == null)
                    return RedirectToAction("Index", "AdminPanel");

                var r = db.Users.Remove(dbUser);

                db.SaveChanges();
            }

            return RedirectToAction("Index", "AdminPanel");
        }

        // POST: KullaniciController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}