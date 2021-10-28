using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingManagmentSystem.Models;

namespace TradingManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        public ItemsContext _db = new ItemsContext();
        public CoinsWrapper _coinsWrapper;

        [HttpGet]
        public ActionResult Index()
        {
            CoinsUpdate();
            _coinsWrapper = new CoinsWrapper();
            _db.SaveChanges();
            return View(_coinsWrapper);
        }
        [HttpPost]
        public string Index(CoinsWrapper coinsWrapper)
        {
            _coinsWrapper = coinsWrapper;
            _coinsWrapper.AddCoin();
            Items buyItems = _db.Items.FirstOrDefault(x => x.Id == coinsWrapper.itemsId);
            if (buyItems.Purchase > coinsWrapper.Money)
            {
                _coinsWrapper.RemoveCoin();
                _coinsWrapper = new CoinsWrapper();
                return "You don't have enough money. Coins will be returned to you";
            }
            string output = "";
            
            _db.SaveChanges();
            return "работает";
        }
        [HttpGet]
        public ActionResult Admin(string Id)
        {
            CoinsUpdate();
            if (Id != "9554390C-3C51-4DF6-AF21-618798258F98")
            {
                return HttpNotFound();
            }
            else
                return View(_coinsWrapper);
        }

        [HttpPost]
        public ActionResult Admin(CoinsWrapper coinsWrapper)
        {
            _coinsWrapper = coinsWrapper;
            coinsWrapper.CoinsToDb();
            return View(coinsWrapper);
        }
        private void CoinsUpdate()
        {
            if (_coinsWrapper == null)
                _coinsWrapper = new CoinsWrapper();
            if (_db.Coins.Count() < 4)
            {
                foreach (var entity in _db.Coins)
                    _db.Coins.Remove(entity);

                _db.Coins.Add(new Coins(1, 1, 0, true));
                _db.Coins.Add(new Coins(2, 2, 0, true));
                _db.Coins.Add(new Coins(3, 5, 0, true));
                _db.Coins.Add(new Coins(4, 10, 0, true));
                _db.SaveChanges();
            }
        }
    }
}