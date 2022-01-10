using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public string Yetki { get; set; }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            ApiKey = string.Empty;
            ApiSecretKey = string.Empty;
            Yetki = string.Empty;
        }
    }
}
