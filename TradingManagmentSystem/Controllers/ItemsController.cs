using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TradingManagmentSystem.Models;

namespace TradingManagmentSystem.Controllers
{
    public class ItemsController : Controller
    {
        public ItemsContext _db = new ItemsContext();
        public CoinsWrapper _coinsWrapper = new CoinsWrapper();
        public HomeController _homeController = new HomeController();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemsWrapper items)
        {
            items.ItemsToDb();
            string fileName = System.IO.Path.GetFileName(items.upload.FileName);
            items.upload.SaveAs(Server.MapPath("~/Images/" + "Photo" + items.currentItems.Id.ToString() + System.IO.Path.GetExtension(fileName)));
            return RedirectToAction("Admin", "Home", new { Id = "9554390C-3C51-4DF6-AF21-618798258F98" });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _db.Items.Remove(_db.Items.FirstOrDefault(a => a.Id == id));
            _db.SaveChanges();
            return RedirectToAction("Admin", "Home", new { Id = "9554390C-3C51-4DF6-AF21-618798258F98" });
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var items = _db.Items.FirstOrDefault(a => a.Id == id);
            var _itemswrapper = new ItemsWrapper(items.Id, items.Purchase, items.Name, items.Count);
            return View(_itemswrapper);
        }
        [HttpPost]
        public ActionResult Edit(ItemsWrapper items)
        {
            items.ItemsToDb();
            string fileName = System.IO.Path.GetFileName(items.upload.FileName);
            items.upload.SaveAs(Server.MapPath("~/Images/" + "Photo" + items.Id.ToString() + System.IO.Path.GetExtension(fileName)));
            return RedirectToAction("Admin", "Home", new { Id = "9554390C-3C51-4DF6-AF21-618798258F98" });
        }

    }
}