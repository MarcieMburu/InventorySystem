﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;

namespace InventoryAPI.Data
{
    public class InventoryAPIContext : DbContext
    {
        public InventoryAPIContext (DbContextOptions<InventoryAPIContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryAPI.Models.InventoryItem > InventoryItems{ get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem >()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
