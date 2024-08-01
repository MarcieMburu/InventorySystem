using System;
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

        public DbSet<InventoryAPI.Models.InventoryDetail> InventoryDetails { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryDetail>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
