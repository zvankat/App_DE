using System.Data.Entity;

namespace OOOFood
{
    public class Food_db : DbContext
    {
        public Food_db() : base("Data Source=DESKTOP-EN8DQSK\\SQLEXPRESS;Initial Catalog=OOOFood_db;Integrated Security=True") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Status> Status { get; set; }

    }
}