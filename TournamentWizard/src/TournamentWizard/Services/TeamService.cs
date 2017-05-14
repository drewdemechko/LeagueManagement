using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Services
{
    public class TeamService : ITeamService
    {
        private AppDbContext database;
        private List<LeagueTeam> teams;

        public TeamService()
        {
            database = new AppDbContext();
            teams = database.LeagueTeam.Include(t => t.League).AsNoTracking().ToList();
        }

        public LeagueTeam Add(LeagueTeam team)
        {
            database.LeagueTeam.Add(team);
            database.SaveChanges();
            return team;
        }

        public LeagueTeam Delete(LeagueTeam team)
        {
            database.LeagueTeam.Remove(team);
            database.SaveChanges();
            return team;
        }

        public List<LeagueTeam> Get()
        {
            return teams;
        }

        public LeagueTeam Get(int id)
        {
            return teams.Where(t => t.Id == id).FirstOrDefault();
        }

        public LeagueTeam Get(string name, int leagueId)
        {
            return teams.Where(t => t.Name == name && t.League.Id == leagueId).FirstOrDefault();
        }

        public List<LeagueTeam> GetFromLeague(int leagueId)
        {
            return teams.Where(t => t.League.Id == leagueId).ToList();
        }
    }
}
