using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OIprojekt.Models;

namespace OIprojekt.DAL
{
    public class PrzepisyContext : DbContext
    {
        public PrzepisyContext():base("PrzepisyContext")
        {

        }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Quantity> Quantities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}