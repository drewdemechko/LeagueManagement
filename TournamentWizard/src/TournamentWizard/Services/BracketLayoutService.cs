using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Services
{
    public class BracketLayoutService : IBracketLayoutService
    {
        private AppDbContext database;
        private List<LeagueTournamentLine> lines;

        public BracketLayoutService()
        {
            database = new AppDbContext();
            lines = database.LeagueTournamentLines.Include(t => t.Tournament).Include(t => t.Competitor).AsNoTracking().ToList();
        }

        public LeagueTournamentLine Add(LeagueTournamentLine tournamentLine)
        {
            database.LeagueTournamentLines.Add(tournamentLine);
            database.SaveChanges();
            return tournamentLine;
        }

        public LeagueTournamentLine Delete(LeagueTournamentLine tournamentLine)
        {
            throw new NotImplementedException();
        }

        public List<LeagueTournamentLine> Get()
        {
            return lines;
        }

        public LeagueTournamentLine Get(int id)
        {
            return lines.Where(l => l.Id == id).FirstOrDefault();
        }

        public LeagueTournamentLine Get(int competitorId, int tournamentId)
        {
            return lines.Where(l => l.Competitor.Id == competitorId && l.Tournament.Id == tournamentId).FirstOrDefault();
        }

        public List<LeagueTournamentLine> GetBracketForTournament(int tournamentId)
        {
            return lines.Where(l => l.Tournament.Id == tournamentId).ToList();
        }
    }
}
