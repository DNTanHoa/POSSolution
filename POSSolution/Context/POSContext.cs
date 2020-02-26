using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using POSSolution.Application.Configurations;
using POSSolution.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace POSSolution.Application.Context
{
    public class POSContext : DbContext
    {
        public POSContext(DbContextOptions<POSContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShopConfiguration());
            builder.ApplyConfiguration(new RegionConfiguration());
            builder.ApplyConfiguration(new ShopStatusConfiguration());
            builder.ApplyConfiguration(new TableConfiguration());
            builder.ApplyConfiguration(new TableStatusConfiguration());
            builder.ApplyConfiguration(new MenuConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new MenuItemConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                                                        .SetBasePath(Directory.GetCurrentDirectory())
                                                        .AddJsonFile("appsettings.json")
                                                        .Build();

            var connectionString = configurationRoot.GetConnectionString("POSContext");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ShopStatus> ShopStatuses { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableStatus> TableStatuses { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
