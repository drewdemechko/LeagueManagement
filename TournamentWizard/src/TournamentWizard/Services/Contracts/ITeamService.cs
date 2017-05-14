using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;

namespace TournamentWizard.Services.Contracts
{
    interface ITeamService
    {
        List<LeagueTeam> Get();
        List<LeagueTeam> GetFromLeague(string leagueName);
        LeagueTeam Add(LeagueTeam team);
        LeagueTeam Delete(int id);
    }
}
