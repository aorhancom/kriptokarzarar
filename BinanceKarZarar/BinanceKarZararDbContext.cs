using BinanceKarZarar.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinanceKarZarar
{
    public class BinanceKarZararDbContext : DbContext
    {
        public DbSet<Entities.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=BinanceKarZararDB;Trusted_Connection=True;");
        }
    }
}