using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanHotelWebApplication.Models
{
    public class Room : Entity
    {
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public int HotelId { get; set; }
        public bool Booked { get; set; }
        public Hotel Hotel { get; set; }
        public List<Cleaner> Cleaners { get; set; }
        public List<CleanerRoom> CleanerRooms { get; set; }
    }
}
