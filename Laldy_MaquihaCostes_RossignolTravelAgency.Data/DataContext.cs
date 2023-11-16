﻿using Microsoft.EntityFrameworkCore;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DestinationEvent> DestinationEvents { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Traveler> Travelers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }
    }
}
