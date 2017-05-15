using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Services
{
    public class LeagueTournamentService : ILeagueTournamentService
    {
        private AppDbContext database;
        private List<LeagueTournament> tournaments;

        public LeagueTournamentService()
        {
            database = new AppDbContext();
            tournaments = database.LeagueTournament.Include(t => t.League).AsNoTracking().ToList();
        }

        public LeagueTournament Add(LeagueTournament tournament)
        {
            database.LeagueTournament.Add(tournament);
            database.SaveChanges();
            return tournament;
        }

        public LeagueTournament Delete(LeagueTournament tournament)
        {
            database.LeagueTournament.Remove(tournament);
            database.SaveChanges();
            return tournament;
        }

        public List<LeagueTournament> Get()
        {
            return tournaments;
        }

        public LeagueTournament Get(string name)
        {
            return tournaments.Where(t => t.Name == name).FirstOrDefault();
        }

        public LeagueTournament Get(int id)
        {
            return tournaments.Where(t => t.Id == id).FirstOrDefault();
        }

        public LeagueTournament Update(LeagueTournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}
