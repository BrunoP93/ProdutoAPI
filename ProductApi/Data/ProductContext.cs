using Microsoft.EntityFrameworkCore;
using ProductApi.Model;

namespace ProductApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {

        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
