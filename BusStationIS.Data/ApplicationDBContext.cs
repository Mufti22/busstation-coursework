using BusStationIS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BusStationIS.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BusStation> BusStations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Distance> Distances { get; set; }
        public DbSet<PaymentCategory> PaymentCategories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<SpecificallyDeparture> SpecificallyDepartures { get; set; }

    }
}
