using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatyaLoyalty.Db.MsSql
{
    public class KatyaLoyaltyMsSqlContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<CustomerToken> CustomerTokens { get; set; }
        public DbSet<OcrReceipt> OcrReceipts { get; set; }
        public DbSet<OcrReceiptItem> OcrReceiptItems { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }
        public DbSet<Reward> Rewards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=katya_loyalty;user id=sa;password=ASD123!@#");
        }
    }
}
