using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TradingManagmentSystem.Models
{
    public partial class CoinsWrapper
    {
        public ItemsContext _db = new ItemsContext();
        public CoinsWrapper()
        {
            this.Avaliable1 = _db.Coins.FirstOrDefault(x => x.Denominations == 1).Avaliable;
            this.Avaliable2 = _db.Coins.FirstOrDefault(x => x.Denominations == 2).Avaliable;
            this.Avaliable5 = _db.Coins.FirstOrDefault(x => x.Denominations == 5).Avaliable;
            this.Avaliable10 = _db.Coins.FirstOrDefault(x => x.Denominations == 10).Avaliable;

            this.Count1 = _db.Coins.FirstOrDefault(x => x.Denominations == 1).Count;
            this.Count2 = _db.Coins.FirstOrDefault(x => x.Denominations == 2).Count;
            this.Count5 = _db.Coins.FirstOrDefault(x => x.Denominations == 5).Count;
            this.Count10 = _db.Coins.FirstOrDefault(x => x.Denominations == 10).Count;
            this.ItemsEnumerable = _db.Items.ToList();
        }
        public void CoinsToDb()
        {
            _db.Coins.FirstOrDefault(x => x.Denominations == 1).Avaliable = this.Avaliable1;
            _db.Coins.FirstOrDefault(x => x.Denominations == 2).Avaliable = this.Avaliable2;
            _db.Coins.FirstOrDefault(x => x.Denominations == 5).Avaliable = this.Avaliable5;
            _db.Coins.FirstOrDefault(x => x.Denominations == 10).Avaliable = this.Avaliable10;

            _db.Coins.FirstOrDefault(x => x.Denominations == 1).Count = this.Count1;
            _db.Coins.FirstOrDefault(x => x.Denominations == 2).Count = this.Count2;
            _db.Coins.FirstOrDefault(x => x.Denominations == 5).Count = this.Count5;
            _db.Coins.FirstOrDefault(x => x.Denominations == 10).Count = this.Count10;
            _db.SaveChanges();
        }

        public void AddCoin()
        {
            _db.Coins.FirstOrDefault(x => x.Denominations == 1).Count += this.Count1;
            _db.Coins.FirstOrDefault(x => x.Denominations == 2).Count += this.Count2;
            _db.Coins.FirstOrDefault(x => x.Denominations == 5).Count += this.Count5;
            _db.Coins.FirstOrDefault(x => x.Denominations == 10).Count += this.Count10;
            sumCoin();
            _db.SaveChanges();
        }

        public void RemoveCoin()
        {
            _db.Coins.FirstOrDefault(x => x.Denominations == 1).Count -= this.Count1;
            _db.Coins.FirstOrDefault(x => x.Denominations == 2).Count -= this.Count2;
            _db.Coins.FirstOrDefault(x => x.Denominations == 5).Count -= this.Count5;
            _db.Coins.FirstOrDefault(x => x.Denominations == 10).Count -= this.Count10;
            sumCoin();
            _db.SaveChanges();
        }

        public void sumCoin()
        {
            this.Money = Count1 + Count2 * 2 + Count5 * 5 +
                         Count10 * 10;
        }
        public int totalSum()
        {
            return _db.Coins.FirstOrDefault(x => x.Denominations == 1).Count + _db.Coins.FirstOrDefault(x => x.Denominations == 2).Count *2 + _db.Coins.FirstOrDefault(x => x.Denominations == 5).Count * 5 + _db.Coins.FirstOrDefault(x => x.Denominations == 10).Count * 10;
        }
        public bool Avaliable1 { get; set; }
        public bool Avaliable2 { get; set; }
        public bool Avaliable5 { get; set; }
        public bool Avaliable10 { get; set; }
        public int itemsId{ get; set; }

        [DisplayName("Count denomination 1")]
        public int Count1 { get; set; }

        [DisplayName("Count denomination 2")]
        public int Count2 { get; set; }

        [DisplayName("Count denomination 5")]
        public int Count5 { get; set; }

        [DisplayName("Count denomination 10")]
        public int Count10 { get; set; }
        public  int Money { get; set; }
        public  IEnumerable<Items> ItemsEnumerable { get; set; }
    }
}