using Microsoft.EntityFrameworkCore;
using snipcart.Models;
 
namespace snipcart
{
    public class InMemoryDB : DbContext
    {
        public InMemoryDB(DbContextOptions<InMemoryDB> options)
            : base(options)
        {
        }
 
        public DbSet<Product> Products { get; set; }
    }
}