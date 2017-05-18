using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;

namespace TournamentWizard.Services.Contracts
{
    public interface ICompetitorService
    {
        List<LeagueCompetitor> Get();
        LeagueCompetitor Get(int id);
        LeagueCompetitor Get(int teamId, int tournamentId);
        List<LeagueCompetitor> GetCompetitorsForTournament(int tournamentId);
        LeagueCompetitor Add(LeagueCompetitor competitor);
        LeagueCompetitor Delete(LeagueCompetitor competitor);
    }
}
