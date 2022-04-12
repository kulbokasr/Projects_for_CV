using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanHotelWebApplication.Models
{
    public class Hotel : Entity
    {
        public string City { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public List<Room> RoomsList { get; set; }
    }
}
