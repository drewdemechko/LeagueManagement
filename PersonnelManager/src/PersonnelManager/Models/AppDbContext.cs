﻿using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManager.Models
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
        public DbSet<Account> Account { get; set; } //All entities have an account
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<CoachAccount> CoachAccount { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<LeagueAdministrator> LeagueAdministrator { get; set; }
        public DbSet<OrganizationAdministrator> OrganizationAdministrator { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerAccount> PlayerAccount { get; set; }
    }
}
