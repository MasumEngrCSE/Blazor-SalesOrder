using Microsoft.EntityFrameworkCore;
using SalesOrder.Api.Entities;

namespace SalesOrder.Api.Data
{
    public class SalesOrderDBContext : DbContext
    {
        public SalesOrderDBContext(DbContextOptions<SalesOrderDBContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region state

            modelBuilder.Entity<StateInfo>().HasData(new StateInfo
                {
                Id = 1,
                    Name = "NY",
                    Description = "New York",
                    CreatedDate = DateTime.Now
                });

            modelBuilder.Entity<StateInfo>().HasData(new StateInfo
                {
                Id=2,
                    Name = "CA",
                    Description = "California",
                    CreatedDate = DateTime.Now
                });

            #endregion
        }

        public DbSet<SubElementType> subElements { get; set; }
        public DbSet<Window> windows { get; set; }
        public DbSet<StateInfo> stateInfo { get; set; }
        public DbSet<UserInfo> users { get; set; }
        public DbSet<OrderMaster> orderMasters { get; set; }

        public DbSet<OrderWindow> orderWindows { get; set; }
        public DbSet<OrderWindowSubElement> orderWindowsSubElements { get; set; }

    }
}
