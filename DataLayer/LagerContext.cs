using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class LagerContext : DbContext
    {
        public LagerContext()
        {

        }
        public LagerContext(DbContextOptions<LagerContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasKey(i => i.ItemId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Item>().HasData(
                new Item { ItemId = 1, ItemName = "Cat6 3m", Discription = "Cat6 netkabel 3 meter langt" },
                new Item { ItemId = 2, ItemName = "Cat6 4m", Discription = "Cat6 netkabel 4 meter langt" },
                new Item { ItemId = 3, ItemName = "Cat6 6m", Discription = "Cat6 netkabel 6 meter langt" },
                new Item { ItemId = 4, ItemName = "HP bærbar", Discription = "HP bærbar i5-4210M, 16GB ram" },
                new Item { ItemId = 5, ItemName = "HDMI 1m", Discription = "HDMI kabel 1 meter langt" },
                new Item { ItemId = 6, ItemName = "HDMI 3m", Discription = "HDMI kabel 3 meter langt" },
                new Item { ItemId = 7, ItemName = "Logitech mus", Discription = "Logitech mus" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Allan" }
                );
        }
    }
}
