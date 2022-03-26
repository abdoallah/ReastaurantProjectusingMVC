using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Core.Models;

namespace Restaurant.Models
{
    public class RestaurantService : IdentityDbContext<AppUser>
    {
        public RestaurantService()
        {

        }
        public RestaurantService(DbContextOptions<RestaurantService> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("Data Source=.;Initial Catalog=Restaurant;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(nameof(OrderItem.Order_Id), nameof(OrderItem.Food_Id));

            base.OnModelCreating(modelBuilder);

        }

    }
}
