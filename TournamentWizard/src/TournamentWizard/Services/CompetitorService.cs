using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Services
{
    public class CompetitorService : ICompetitorService
    {
        private AppDbContext database;
        private List<LeagueCompetitor> competitors;

        public CompetitorService()
        {
            database = new AppDbContext();
            competitors = database.LeagueCompetitor.Include(c => c.Team).Include(c => c.Tournament).AsNoTracking().ToList();
        }

        public LeagueCompetitor Add(LeagueCompetitor competitor)
        {
            database.LeagueCompetitor.Add(competitor);
            database.SaveChanges();
            return competitor;
        }

        public LeagueCompetitor Delete(LeagueCompetitor competitor)
        {
            database.LeagueCompetitor.Remove(competitor);
            database.SaveChanges();
            return competitor;
        }

        public List<LeagueCompetitor> Get()
        {
            return competitors;
        }

        public LeagueCompetitor Get(int id)
        {
            return competitors.Where(c => c.Id == id).FirstOrDefault();
        }

        public LeagueCompetitor Get(int teamId, int tournamentId)
        {
            return competitors.Where(c => c.Team.Id == teamId && c.Tournament.Id == tournamentId).FirstOrDefault();
        }

        public List<LeagueCompetitor> GetCompetitorsForTournament(int tournamentId)
        {
            return competitors.Where(c => c.Tournament.Id == tournamentId).ToList();
        }
    }
}
