using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BootstrapExample.Models
{
    public class LeagueContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}