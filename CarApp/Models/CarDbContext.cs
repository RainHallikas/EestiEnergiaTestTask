using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CarApp.Models
{
    public class CarDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarMark>().ToTable("CarMarks");
            modelBuilder.Entity<SparePart>().ToTable("SpareParts");
            modelBuilder.Entity<CarSparePart>().ToTable("CarSpareParts");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CarMark> CarMarks { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<CarSparePart> CarSpareParts { get; set; }
    }
}