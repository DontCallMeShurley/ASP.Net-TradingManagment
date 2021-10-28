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
        public ActionResult Index(CoinsWrapper coinsWrapper)
        {
            _coinsWrapper = coinsWrapper;
            _coinsWrapper.AddCoin();
            var dbCoins = new CoinsWrapper();
            Items buyItems = _db.Items.FirstOrDefault(x => x.Id == coinsWrapper.itemsId);
            if (buyItems.Purchase > coinsWrapper.Money)
            {
                _coinsWrapper.RemoveCoin();
                _coinsWrapper = new CoinsWrapper();
                ViewBag.Info =  "You don't have enough money. Coins will be returned to you";
                return View(dbCoins);
            }
            int[] coinsToChange = new int[4];//0-1 denomination, 1-2 denomination, 2-5 denomination, 3-10 denomination
            int change = coinsWrapper.Money - buyItems.Purchase;
            string output = "You bought " + buyItems.Name + " for the price " + buyItems.Purchase + ". You deposited " + coinsWrapper.Money + " coins. You change must be is " + (coinsWrapper.Money - buyItems.Purchase) + ".";

            int coinsMax = 10;
            for (int i = 3; i >= 0; i--)
            {
                if (_db.Coins.FirstOrDefault(x => x.Denominations == coinsMax).Count >= change / coinsMax && change / coinsMax != 0)
                {
                    coinsToChange[i] = change / coinsMax;
                    change = change % coinsMax;
                }
                coinsMax = coinsMax / 2;
            }
            if (change > 0)
            {
                _coinsWrapper.RemoveCoin();
                output += " There are not enough coins to give you change. Coins will be returned to you";
                ViewBag.Info = output;
                return View(dbCoins);
            }
            dbCoins.Count1 = coinsToChange[0];
            dbCoins.Count2 = coinsToChange[1];
            dbCoins.Count5 = coinsToChange[2];
            dbCoins.Count10 = coinsToChange[3];
            dbCoins.RemoveCoin();
            buyItems.Count -= 1;
            dbCoins.ItemsEnumerable = _db.Items;
            if (coinsWrapper.Money - buyItems.Purchase > 0)
                output += " You will be given " + coinsToChange[0] + " coins of denomination 1, " + coinsToChange[1] + " coins of denomination 2, " + coinsToChange[2]
                    + " coins of denomination 5, " + coinsToChange[3] + " coins of denomination 10";

            _db.SaveChanges();
            ViewBag.Info = output;
            return View(dbCoins);
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
            if (_coinsWrapper == null)
                _coinsWrapper = new CoinsWrapper();
        }
    }
}