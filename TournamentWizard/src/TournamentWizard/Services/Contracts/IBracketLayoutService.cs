using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;

namespace TournamentWizard.Services.Contracts
{
    //Maintains Tournament lines
    public interface IBracketLayoutService
    {
        List<LeagueTournamentLine> Get();
        LeagueTournamentLine Get(int id);
        LeagueTournamentLine Get(int competitorId, int tournamentId);
        List<LeagueTournamentLine> GetBracketForTournament(int tournamentId);
        LeagueTournamentLine Add(LeagueTournamentLine tournamentLine);
        LeagueTournamentLine Delete(LeagueTournamentLine tournamentLine);
    }
}
