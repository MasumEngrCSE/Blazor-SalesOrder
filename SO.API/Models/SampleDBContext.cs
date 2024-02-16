using Microsoft.EntityFrameworkCore;

namespace SO.API.Models
{
    public class SampleDBContext : DbContext
    {
        public SampleDBContext(DbContextOptions<SampleDBContext> options): base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }

}
