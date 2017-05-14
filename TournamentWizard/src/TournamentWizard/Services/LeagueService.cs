using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Services
{
    public class LeagueService : ILeagueService
    {
        private AppDbContext database;
        private List<League> leagues;

        public LeagueService()
        {
            database = new AppDbContext();
            leagues = database.League.AsNoTracking().ToList();
        }

        public League Add(League league)
        {
            database.League.Add(league);
            database.SaveChanges();
            return league;
        }

        public League Delete(League league)
        {
            database.League.Remove(league);
            database.SaveChanges();
            return league;
        }

        public List<League> Get()
        {
            return leagues;
        }

        public League Get(int id)
        {
            return leagues.Where(l => l.Id == id).FirstOrDefault();
        }

        public League Get(string name)
        {
            return leagues.Where(l => l.Name == name).FirstOrDefault();
        }

        public League Update(League league)
        {
            database.League.Update(league);
            database.SaveChanges();
            return league;
        }
    }
}
