using CleanHotelWebApplication.Data;
using CleanHotelWebApplication.Dtos;
using CleanHotelWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanHotelWebApplication.Controllers
{
    public class HotelController : Controller
    {
        private DataContext _context;

        public HotelController(DataContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            var hotelRoom = new HotelRoom()
            {
                Hotels = _context.Hotels.Include(i => i.RoomsList).ToList(),
                Rooms = _context.Rooms.ToList()

             };
            return View(hotelRoom);
        }
        [HttpGet]
        public IActionResult AddHotel()
        {
            var hotel = new Hotel();
            return View(hotel);
        }
        [HttpPost]
        public IActionResult AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditHotel(int id)
        {
            var hotel = _context.Hotels.Find(id);
            return View(hotel);
        }
        [HttpPost]
        public IActionResult EditHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
