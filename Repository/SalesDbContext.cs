using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.ViewModels.Response;

namespace Repository
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {
        }

        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options) 
        { 
        }

        public virtual DbSet<AddSalesResponse> AddSalesResponses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //modelBuilder.Entity<AddSalesResponse>( eb => {
            //    eb.HasNoKey();
            //});
            modelBuilder.Entity<AddSalesResponse>().HasNoKey();

        }
    }
}
