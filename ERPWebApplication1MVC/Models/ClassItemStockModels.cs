using System;
using System.Data.Entity;

namespace ERPWebApplication1MVC.Models
{
    public class ItemStockModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class ItemStockContext : DbContext
    {
        public DbSet<ItemStockModels> StockModel { get; set; }
    }
}