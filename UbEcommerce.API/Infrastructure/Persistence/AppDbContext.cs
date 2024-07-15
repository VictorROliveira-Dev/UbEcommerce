using Microsoft.EntityFrameworkCore;
using UbEcommerce.API.Domain.Entities;

namespace UbEcommerce.API.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
