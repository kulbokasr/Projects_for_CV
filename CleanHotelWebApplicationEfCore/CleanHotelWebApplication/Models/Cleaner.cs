using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanHotelWebApplication.Models
{
    public class Cleaner : Entity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public List<Room> Rooms { get; set; }
        public List<CleanerRoom> CleanerRooms { get; set; }
    }
}
