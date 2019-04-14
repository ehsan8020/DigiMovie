using System;
using System.Collections.Generic;
using System.Text;
using DigiMovie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigiMovie.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder
            //    .Entity<Product>()
            //    .Property(p => p.NumberInStock)
            //    .HasDefaultValue(50);
        }

        public DbSet<Product> Products { get; set; }
    }
}
