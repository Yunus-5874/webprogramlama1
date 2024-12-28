﻿using BerberWebSitesi.Models;
using Microsoft.EntityFrameworkCore;

namespace BerberWebSitesi.Data
{
    public class BerberContext : DbContext
    {
        public BerberContext(DbContextOptions<BerberContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }

    }
}
