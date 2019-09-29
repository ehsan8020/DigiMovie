using System;
using System.Collections.Generic;
using System.Text;
using HiShop.Areas.Identity.Data;
using HiShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HiShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
            //    .Property(p => p.CatId)
            //    .HasDefaultValue(1);

            //Edit Relation Between Category And Products (Delete Rule becomes Restrict)
            //builder
            //       .Entity<Product>()
            //       .HasOne(p => p.Category)
            //       .WithMany(b => b.Products)
            //       .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
