using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TradingManagmentSystem.Models
{
    public class ItemsContext : DbContext
    { 
        public DbSet<Items> Items { get; set; }
        public DbSet<Coins> Coins { get; set; }
    }
}