using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingManagmentSystem.Models
{
    public class Items
    {
        public Items(int id, int purchase, string name, int count)
        {
            this.Id = id;
            this.Purchase = purchase;
            this.Name = name;
            this.Count = count;
        }

        public Items()
        {
        }

        public int Id { get; set; }
        public int Purchase { get; set; }
        public String Name { get; set; }
        public int Count { get; set; }
    }
}