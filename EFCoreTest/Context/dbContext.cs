using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using EFCoreTest.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest.Context
{
    class dbContext:DbContext
    {
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EcomDatabase"].ConnectionString);
        }
    }
}
