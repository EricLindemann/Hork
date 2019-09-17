extern alias MySqlConnectorAlias;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Proxies;
using Hork_Api.Helpers;

namespace Hork_Api.Entities
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
            // TODO generalize this V            
            modelBuilder.Entity<ExerciseDetail>().UseTimestampedProperty();
            modelBuilder.Entity<Workout>().UseTimestampedProperty();
            modelBuilder.Entity<Exercise>().UseTimestampedProperty();
        }

        private MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlConnection GetConnection() {
            return new MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlConnection(ConnectionString);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLazyLoadingProxies();

        public DbSet<ExerciseDetail> ExerciseDetails { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
