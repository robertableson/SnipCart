using Microsoft.EntityFrameworkCore;
using snipcart.Models;
 
namespace snipcart
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
 
        public DbSet<Product> Products { get; set; }
    }
}