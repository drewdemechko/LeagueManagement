using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWizard.Models
{
    public class AppDbContext : DbContext
    {
        private static bool _created = false;

        public AppDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        public IConfigurationRoot Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json");
            Configuration = configuration.Build();
            optionsBuilder.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        //Entities in database
        public DbSet<League> League { get; set; }
        public DbSet<LeagueTournament> LeagueTournament { get; set; }
        public DbSet<LeagueCompetitor> LeagueCompetitor { get; set; }
        public DbSet<LeagueTeam> LeagueTeam { get; set; }
        public DbSet<LeagueTournamentLines> LeagueTournamentLines { get; set; }
    }
}
