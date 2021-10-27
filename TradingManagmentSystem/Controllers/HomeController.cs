﻿using System;
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

        [HttpGet]
        public ActionResult Index()
        {
            _db.Coins.Add(new Coins(1, 2, 4, true));
            _db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Admin(string Id)
        {
            var coinsWrapper = new CoinsWrapper();
            if (Id != "9554390C-3C51-4DF6-AF21-618798258F98")
            {
                return View("Index");
            }
            else
                return View(coinsWrapper);
        }

        [HttpPost]
        public ActionResult Admin(CoinsWrapper coinsWrapper)
        {
            var a = coinsWrapper;
            return View("Index");
        }
    }
}