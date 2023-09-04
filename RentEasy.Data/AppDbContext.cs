using Microsoft.EntityFrameworkCore;
using RentEasy.Models;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace RentEasy.Data
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString= @"Server=DESKTOP-KTAN054; Initial Catalog=RentEasyEf; Integrated Security=true; Trusted_Connection=true";

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Client> Clients { get; set; }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
