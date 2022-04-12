using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopApplication.Controllers
{
    public class ShopController : Controller
    {
        private DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Shop> shops = new List<Shop>();
            shops = _context.Shops.Include(c => c.Items).ThenInclude(c => c.ItemTags).ThenInclude(c => c.Tag).ToList();
            return View(shops);
        }
        [HttpGet]
        public IActionResult AddShop()
        {
            var shop = new Shop();
            return View(shop);
        }
        [HttpPost]
        public IActionResult AddShop(Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }
            _context.Shops.Add(shop);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public  IActionResult DeleteShop(int id)
        {
            var shop = _context.Shops.Find(id);
            _context.Shops.Remove(shop);
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public IActionResult UpdateShop(int id)
        {
            var shop = _context.Shops.Find(id);
            return View(shop);
        }
        [HttpPost]
        public IActionResult UpdateShop(Shop shop)
        {
            _context.Shops.Update(shop);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
