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
    public class CleanerController : Controller
    {
        private DataContext _context;

        public CleanerController(DataContext context)
        {
            _context = context;
        }
        public IActionResult ListCleaners()
        {
            var cleaners = _context.Cleaners.ToList();
            return View(cleaners);
        }

        [HttpGet]
        public IActionResult AddCleaner()
        {
            var cleaner = new Cleaner();
            return View(cleaner);
        }
        [HttpPost]
        public IActionResult AddCleaner(Cleaner cleaner)
        {
            _context.Cleaners.Add(cleaner);
            _context.SaveChanges();
            return RedirectToAction("ListCleaners");
        }
        public IActionResult EditCleaner(int id)
        {
            var cleaner = _context.Cleaners.Find(id);
            return View(cleaner);
        }
        [HttpPost]
        public IActionResult EditCleaner(Cleaner cleaner)
        {
            _context.Cleaners.Update(cleaner);
            _context.SaveChanges();
            return RedirectToAction("ListCleaners");
        }

        public IActionResult AssignCleaner(int roomId)
        {
            var hotelRoom = new HotelRoom()
            {
                Hotels = _context.Hotels.Include(i => i.RoomsList).ToList(),
                Rooms = _context.Rooms.Include(i => i.Hotel).ToList(),
                Room = _context.Rooms.Find(roomId),
                AllCleaners = _context.Cleaners.ToList(),
                UsableCleaners = new List<Cleaner>()
            };
            hotelRoom.Room = _context.Rooms.Where(i => i.Id == roomId).Include(i => i.Hotel).FirstOrDefault();
            hotelRoom.UsableCleaners.AddRange(_context.Cleaners.Where(c => c.City == hotelRoom.Room.Hotel.City).ToList());
            foreach (var cleaner in hotelRoom.UsableCleaners.ToList())
            {
                int count = _context.CleanersRooms.Where(i => i.CleanerId == cleaner.Id & i.Cleaned == false).Count();
                if (count >= 5)
                {
                    hotelRoom.UsableCleaners.Remove(cleaner);
                }
            }
            return View(hotelRoom);
        }
        [HttpPost]
        public IActionResult AssignCleaner(HotelRoom hotelRoom)
        {
            CleanerRoom cleanerRoom = new CleanerRoom();
            cleanerRoom.RoomId = hotelRoom.Room.Id;
            cleanerRoom.CleanerId = hotelRoom.Cleaner.Id;
            _context.CleanersRooms.Add(cleanerRoom);
            _context.SaveChanges();
            return RedirectToAction("ListRooms", "Room");
        }

        public IActionResult CleanersRooms (int cleanerId)
        {
            List<CleanerRoom> items = new List<CleanerRoom>();
            items = _context.CleanersRooms.Where(c => c.CleanerId == cleanerId & c.Cleaned !=true).Include(i => i.Room).ToList();
            return View(items);
        }
        public IActionResult CleanRoom(int roomid, int cleanerid)
        {
            var item = _context.CleanersRooms.Find(cleanerid, roomid);
            item.Cleaned = true;
            _context.CleanersRooms.Update(item);
            _context.SaveChanges();
            return RedirectToAction("ListCleaners");
        }
    }
}
