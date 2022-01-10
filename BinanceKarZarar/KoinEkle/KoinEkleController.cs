using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar.KoinEkle
{
    public class KoinEkleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
