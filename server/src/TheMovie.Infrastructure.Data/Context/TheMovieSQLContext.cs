using Microsoft.EntityFrameworkCore;

using TheMovie.Domain.Entities;

using Microsoft.Extensions.Configuration;
using System.IO;
using TheMovie.Infrastructure.Data.Mappings;
using TheMovie.Infrastructure.Data.Externsions;
using Microsoft.EntityFrameworkCore.Design;

namespace TheMovie.Infrastructure.Data.Context
{
    public class TheMovieSQLContext : DbContext
    {
        private readonly DbContextOptions options;

        public DbSet<Filme> Filmes { get; set; }

        public TheMovieSQLContext(DbContextOptions<TheMovieSQLContext> options)
            : base(options)
        {
            this.options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new FilmeMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }

    public class TheMovieSQLContextFactory : IDesignTimeDbContextFactory<TheMovieSQLContext>
    {
        public TheMovieSQLContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TheMovieSQLContext>();
            optionsBuilder.UseSqlServer("DefaultConnection");

            return new TheMovieSQLContext(optionsBuilder.Options);
        }
    }
}
