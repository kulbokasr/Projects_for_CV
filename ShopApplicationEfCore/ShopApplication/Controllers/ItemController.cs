using Microsoft.AspNetCore.Mvc;
using ShopApplication.Data;
using ShopApplication.Dtos;
using ShopApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopApplication.Controllers
{
    public class ItemController : Controller
    {
        private DataContext _context;

        public ItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            var createItem = new CreateItem()
            {
                Item = new Item(),
                Tags = _context.Tags.ToList(),
                AllShops = _context.Shops.ToList()
        };
            
            return View(createItem);
        }
        [HttpPost]
        public IActionResult AddItem(CreateItem createItem)
        {
            if (!ModelState.IsValid)
            {
                createItem.AllShops = _context.Shops.ToList();
                return View(createItem);
            }
            _context.Items.Add(createItem.Item);
            _context.SaveChanges();

            foreach (var tagId in createItem.SelectedTagIds)
            {
                _context.ItemTags.Add(new ItemTag()
                {
                    TagId = tagId,
                    ItemId = createItem.Item.Id
                });
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Shop");
        }

        public IActionResult DeleteItem(int id)
        {
            var item = _context.Items.Find(id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index", "Shop");
        }

        public IActionResult UpdateItem(int id)
        {
            var createItem = new CreateItem()
            {
                Item = _context.Items.Find(id),
                Tags = _context.Tags.ToList(),
                AllShops = _context.Shops.ToList()
            };
            return View(createItem);
        }
        [HttpPost]
        public IActionResult UpdateItem(CreateItem createItem)
        {
            var delItemTags = _context.ItemTags.Where(c => c.ItemId == createItem.Item.Id).ToList();
            _context.ItemTags.RemoveRange(delItemTags);
            _context.SaveChanges();
            _context.Items.Update(createItem.Item);
            _context.SaveChanges();
            foreach (var tagId in createItem.SelectedTagIds)
            {
                _context.ItemTags.Add(new ItemTag()
                {
                    TagId = tagId,
                    ItemId = createItem.Item.Id
                });
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Shop");
        }


    }
}
