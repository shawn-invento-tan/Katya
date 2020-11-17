using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
    public class KatyaLoyaltyMsSqlContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<CustomerToken> CustomerTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=katya_loyalty;user id=sa;password=ASD123!@#");
        }
    }
}
