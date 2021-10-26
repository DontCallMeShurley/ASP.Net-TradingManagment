using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TradingManagmentSystem.Models
{
    public class Coins
    {
         public int Id { get; set; }
        public int Denominations { get; set; }
        public int Count { get; set; }
        public bool Avaliable { get; set; }
    }
}