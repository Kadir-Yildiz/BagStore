﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class BagStoreContext : DbContext
    {
        public BagStoreContext(DbContextOptions<BagStoreContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Basket> Baskets => Set<Basket>();
        public DbSet<BasketItem> BasketItems => Set<BasketItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
