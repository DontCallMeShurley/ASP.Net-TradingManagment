using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace TradingManagmentSystem.Models
{
    public partial class ItemsWrapper
    {
        public ItemsContext _db = new ItemsContext();
        public ItemsWrapper(int id, int purchase, string name, int count)
        {
            this.Id = id;
            this.Purchase = purchase;
            this.Name = name;
            this.Count = count;
        }

        public ItemsWrapper()
        {

        }
        public void ItemsToDb()
        {
            Items item = new Items(this.Id, this.Purchase, this.Name, this.Count);
            _db.Items.AddOrUpdate(item);
            _db.SaveChanges();
            currentItems = item;
        }
        public int Id { get; set; }
        public int Purchase { get; set; }
        public String Name { get; set; }
        public int Count { get; set; }
        public Items currentItems { get; set; }
        public HttpPostedFileBase upload { get; set; }
    }
}