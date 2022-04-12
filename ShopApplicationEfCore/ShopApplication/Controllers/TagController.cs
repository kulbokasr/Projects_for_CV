using Microsoft.AspNetCore.Mvc;
using ShopApplication.Data;
using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Controllers
{
    public class TagController : Controller
    {
        private DataContext _context;

        public TagController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult AddTag()
        {
            var tag = new Tag();
            return View(tag);
        }
        [HttpPost]
        public IActionResult AddTag(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View(tag);
            }
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("GetTags");
        }

        public IActionResult GetTags()
        {
            var tags = _context.Tags.ToList();
            return View(tags);
        }

        public IActionResult DeleteTag(int id)
        {
            var tag = _context.Tags.Find(id);
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("GetTags");
        }

        public IActionResult UpdateTag(int id)
        {
            var tag = _context.Tags.Find(id);
            return View(tag);
        }
        [HttpPost]
        public IActionResult UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
            _context.SaveChanges();
            return RedirectToAction("GetTags");
        }

        public IActionResult DeleteItemTag(int tagId, int itemId)
        {
            ItemTag ítemtag = _context.ItemTags.First(c => c.ItemId == itemId & c.TagId == tagId);
            _context.ItemTags.Remove(ítemtag);
            _context.SaveChanges();
            return RedirectToAction("Index", "Shop");
        }

    }
}
