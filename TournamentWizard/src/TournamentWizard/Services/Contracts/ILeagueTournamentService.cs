using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;

namespace TournamentWizard.Services.Contracts
{
    public interface ILeagueTournamentService
    {
        List<LeagueTournament> Get();
        LeagueTournament Get(int id);
        LeagueTournament Get(string name);
        LeagueTournament Delete(LeagueTournament tournament);
        LeagueTournament Update(LeagueTournament tournament);
        LeagueTournament Add(LeagueTournament tournament);
    }
}
