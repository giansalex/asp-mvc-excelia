using ExceliaMvc.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExceliaMvc.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("ExceliaContext")
        {

        }

        public DbSet<Direction> Directions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}