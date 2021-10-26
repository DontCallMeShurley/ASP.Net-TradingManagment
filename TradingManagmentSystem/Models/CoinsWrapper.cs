using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingManagmentSystem.Models
{
    public partial class CoinsWrapper
    {
        public bool Avaliable1 { get; set; }
        public bool Avaliable2 { get; set; }
        public bool Avaliable5 { get; set; }
        public bool Avaliable10 { get; set; }

        public int Count1 { get; set; }
        public int Count2 { get; set; }
        public int Count5 { get; set; }
        public int Count10 { get; set; }
    }
}