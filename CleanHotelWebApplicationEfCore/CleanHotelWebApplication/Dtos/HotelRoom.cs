using CleanHotelWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanHotelWebApplication.Dtos
{
    public class HotelRoom
    {
        public List<Hotel> Hotels { get; set; }
        public List<Room> Rooms { get; set;}
        public List<Room> UsableRooms { get; set;}
        public Room Room { get; set; }
        public List<BookedDropDown> TrueFalse { get; set; }
        public Cleaner Cleaner { get; set; }
        public List<Cleaner> AllCleaners { get; set; }
        public List<Cleaner> UsableCleaners { get; set; }
        public string errormsg { get; set; }

    }
}
