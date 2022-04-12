using CleanHotelWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanHotelWebApplication.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Cleaner> Cleaners { get; set; }
        public DbSet<CleanerRoom> CleanersRooms { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CleanerRoom>()
            .HasKey(bc => new { bc.CleanerId, bc.RoomId });
        }

    }
}
