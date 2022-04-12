using Microsoft.EntityFrameworkCore;
using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopApplication.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ItemTag>()
            .HasKey(bc => new { bc.TagId, bc.ItemId });

            base.OnModelCreating(builder);

            builder.Entity<Shop>().Property<bool>("IsDeleted");
            builder.Entity<Shop>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<Item>().Property<bool>("IsDeleted");
            builder.Entity<Item>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.Entity<ItemTag>().Property<bool>("IsDeleted");
            builder.Entity<ItemTag>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        //public override Task SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    UpdateSoftDeleteStatuses();
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Shop>().HasData(
        //        new Shop()
        //        {
        //            Id = 1,
        //            Name = "Shop1",
        //        },
        //         new Shop()
        //         {
        //             Id = 2,
        //             Name = "Shop2"
        //         },
        //        new Shop()
        //        {
        //            Id = 3,
        //            Name = "Shop3"
        //        }
        //        );
        //    modelBuilder.Entity<Item>().HasData(
        //        new Item()
        //        {
        //            Id = 1,
        //            Name = "Item1",
        //            ShopId = 1
        //        },
        //         new Item()
        //         {
        //            Id = 2,
        //            Name = "Item2",
        //            ShopId = 1
        //         },
        //        new Item()
        //        {
        //            Id = 3,
        //            Name = "Item3",
        //            ShopId = 1
        //        },
        //        new Item()
        //        {
        //            Id = 4,
        //            Name = "Item4",
        //            ShopId = 2
        //        },
        //        new Item()
        //        {
        //            Id = 5,
        //            Name = "Item5",
        //            ShopId = 2
        //        }
        //        );

        //}
    }
}
