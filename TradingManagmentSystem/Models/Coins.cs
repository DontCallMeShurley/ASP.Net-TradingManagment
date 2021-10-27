using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TradingManagmentSystem.Models
{
    public class Coins
    {
        public Coins(int Id, int Denominations, int Count, bool Avaliable)
        {
            this.Id = Id;
            this.Denominations = Denominations;
            this.Count = Count;
            this.Avaliable = Avaliable;
        }
        public Coins()
        {
           
        }
         public int Id { get; set; }
        public int Denominations { get; set; }
        public int Count { get; set; }
        public bool Avaliable { get; set; }
    }
}