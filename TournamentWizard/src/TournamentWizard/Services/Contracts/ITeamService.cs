using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;

namespace TournamentWizard.Services.Contracts
{
    public interface ITeamService
    {
        List<LeagueTeam> Get();
        LeagueTeam Get(int id);
        LeagueTeam Get(string name, int leagueId);
        List<LeagueTeam> GetFromLeague(int leagueId);
        LeagueTeam Add(LeagueTeam team);
        LeagueTeam Delete(LeagueTeam team);
    }
}
