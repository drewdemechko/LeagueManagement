using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;

namespace TournamentWizard.Services.Contracts
{
    public interface ILeagueService
    {
        List<League> Get();
        League Get(int id);
        League Get(string name);
        League Add(League league);
        League Delete(League league);
        League Update(League league);
    }
}
