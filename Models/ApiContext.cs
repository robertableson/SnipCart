using Microsoft.EntityFrameworkCore;
using snipcart.DbModels;
 
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