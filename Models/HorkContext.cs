extern alias MySqlConnectorAlias;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Hork_Api.Helpers;

namespace Hork_Api.Models
{
    public class HorkContext : DbContext
    {
        public string ConnectionString { get; set; }
        public HorkContext(DbContextOptions<HorkContext> options)
            : base(options)
        {
            // TODO whaa
            ConnectionString = ((MySqlOptionsExtension)options.Extensions.Single(x => x is MySqlOptionsExtension)).ConnectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Use the entity name instead of the Context.DbSet<T> name
                // refs https://docs.microsoft.com/en-us/ef/core/modeling/relational/tables#conventions
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
            
            modelBuilder.Entity<Exercise>().UseTimestampedProperty();
        }

        private MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlConnection GetConnection() {
            return new MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlConnection(ConnectionString);
        }

        public DbSet<Exercise> Exercises { get; set; }
    }
}
