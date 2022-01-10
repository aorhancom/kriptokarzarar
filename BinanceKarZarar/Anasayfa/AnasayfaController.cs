using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using BinanceKarZararModel;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BinanceKarZarar.Anasayfa
{
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {

            try
            {
                var userId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));

                if (userId == 0)
                    return RedirectToAction("Index", "AuthLogin");


                string username = "";
                string apiKey = "";
                string secretKey = "";

                using (var db = new BinanceKarZararDbContext())
                {
                    var dbUser = db.Users.FirstOrDefault(x => x.Id == userId);

                    username = dbUser.Username;
                    apiKey = dbUser.ApiKey;
                    secretKey = dbUser.ApiSecretKey;
                }

                KoinApiModel koinApiModel = new KoinApiModel();

                koinApiModel.KoinModels = GetUserCoins(username, apiKey, secretKey);

                return View(koinApiModel);
            }
            catch (Exception)
            {

                //return View(new KoinApiModel() {KoinModels = new List<KoinModel>() });
                return RedirectToAction("Index", "ApiEkle");

            }

        }

        public List<KoinModel> GetUserCoins(string username, string apiKey, string secretKey)
        {
            try
            {
                WebClient client = new WebClient();

                var requestUrl = $"https://sametdemirel.com/coin/test/api.php?type={username},{apiKey},{secretKey}";

                var json = client.DownloadString(requestUrl);

                return JsonConvert.DeserializeObject<List<KoinModel>>(json);

            }
            catch (Exception)
            {

                return new List<KoinModel>();
            }
        }
    }
}