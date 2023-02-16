using EduBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduBook.DataAccess.Data
{
    // tạo class ApplicationDbContext kế thừa IdentityDbContext
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // tạo table dựa vào class
        public DbSet<Category>? Categories { get; set; }
        public DbSet<CoverType>? CoverTypes { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<ShoppingCart>? ShoppingCarts { get; set; }
        public DbSet<OrderHeader>? OrderHeaders { get; set; }
        public DbSet<OrderDetails>? OrderDetails { get; set; }
    }
}