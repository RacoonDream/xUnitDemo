using Microsoft.EntityFrameworkCore;
using JWTAuthDemo.Entities;

namespace JWTAuthDemo.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}