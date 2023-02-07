using Microsoft.EntityFrameworkCore;
using SalesOrder.Api.Entities;

namespace SalesOrder.Api.Data
{
    public class SalesOrderDBContext:DbContext
    {
        public SalesOrderDBContext(DbContextOptions<SalesOrderDBContext> options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SubElement> subElements { get; set; }
        public DbSet<Window> windows { get; set; }
        public DbSet<StateInfo> stateInfo { get; set; }
        public DbSet<UserInfo> users { get; set; }
        public DbSet<OrderMaster> orderMasters { get; set; }

        public DbSet<OrderWindow> orderWindows { get; set; }
        public DbSet<OrderWindowSubElement> orderWindowsSubElements { get; set; }

    }
}
