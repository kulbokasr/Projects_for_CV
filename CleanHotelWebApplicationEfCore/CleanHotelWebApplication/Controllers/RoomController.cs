using CleanHotelWebApplication.Data;
using CleanHotelWebApplication.Dtos;
using CleanHotelWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CleanHotelWebApplication.Controllers
{
    public class RoomController : Controller
    {
        private DataContext _context;

        public RoomController(DataContext context)
        {
            _context = context;
        }
        public IActionResult BookRoom(int id)
        {
            var room = _context.Rooms.Find(id);
            room.Booked = true;
            _context.Rooms.Update(room);
            _context.SaveChanges();
            return RedirectToAction("Index", "Hotel");
            
        }

        public IActionResult AddRoom(int? hotelid)
        {
            if (hotelid == null)
            { 
            var hotelRoom = new HotelRoom()
            {
                Hotels = _context.Hotels.Where(h => h.Rooms > h.RoomsList.Count).Include(i => i.RoomsList).ToList(),
                Rooms = _context.Rooms.ToList()

            };
            return View(hotelRoom);
            }
            else
            {
                var hotelRoom = new HotelRoom()
                {
                    Hotels = _context.Hotels.Where(h => h.Id == hotelid).ToList(),
                    Rooms = _context.Rooms.ToList()

                };
                return View(hotelRoom);
            }
        }


        [HttpPost]
        public IActionResult AddRoom(HotelRoom hotelRoom)
        {
            _context.Rooms.Add(hotelRoom.Room);
            _context.SaveChanges();
            return RedirectToAction("Index", "Hotel");
        }

        public IActionResult EditRoom(int id)
        {
            var hotelRoom = new HotelRoom()
            {
                Hotels = _context.Hotels.Where(h => h.Rooms > h.RoomsList.Count).Include(i => i.RoomsList).ToList(),
                Rooms = _context.Rooms.ToList(),
                TrueFalse =  new List<Models.BookedDropDown>() { 
                    new Models.BookedDropDown { Value = "true", Text = "Yes" }, 
                    new Models.BookedDropDown { Value = "false", Text = "No" } 
                },

                Room = _context.Rooms.Find(id)

            };
            return View(hotelRoom);

        }
        [HttpPost]
        public IActionResult EditRoom(HotelRoom hotelRoom)
        {
            _context.Rooms.Update(hotelRoom.Room);
            _context.SaveChanges();
            return RedirectToAction("ListRooms");
        }
        public IActionResult ListRooms()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        public IActionResult AssignRoom(int cleanerId)
        {
            var cleanerroomscount = _context.Cleaners.Where(i => i.Id == cleanerId).Include(i => i.CleanerRooms).FirstOrDefault();
            if (cleanerroomscount.CleanerRooms.Count >= 5)
            {
                var hotelRoom = new HotelRoom()
                {
                    errormsg = "Cleaner already has 5 rooms to clean"
                };
                return View("Error");
            
            }

            else
            { 
            var hotelRoom = new HotelRoom()
            {
                Hotels = _context.Hotels.Include(i => i.RoomsList).ToList(),
                Rooms = _context.Rooms.Include(i => i.Hotel).ToList(),
                Cleaner = _context.Cleaners.Find(cleanerId),
                AllCleaners = _context.Cleaners.ToList(),
                UsableCleaners = new List<Cleaner>(),
                UsableRooms = new List<Room>() 
            };
            hotelRoom.Cleaner = _context.Cleaners.Where(i => i.Id == cleanerId).FirstOrDefault();
            hotelRoom.UsableRooms.AddRange(_context.Rooms.Include(i => i.CleanerRooms).Where(i => i.Hotel.City == hotelRoom.Cleaner.City)./*Where(neisvalyti kambariai).*/Where(i => i.CleanerRooms.Count == 0).ToList());
            return View(hotelRoom);
            }
        }
        [HttpPost]
        public IActionResult AssignRoom(HotelRoom hotelRoom)
        {
            CleanerRoom cleanerRoom = new CleanerRoom();
            cleanerRoom.RoomId = hotelRoom.Room.Id;
            cleanerRoom.CleanerId = hotelRoom.Cleaner.Id;
            _context.CleanersRooms.Add(cleanerRoom);
            _context.SaveChanges();
            return RedirectToAction("ListCleaners", "Cleaner");
        }

    }
}
