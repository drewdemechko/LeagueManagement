using PersonnelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManager.Services.Contracts
{
    public interface ILeagueAdministratorDomainService
    {
        List<LeagueAdministrator> Get();
        LeagueAdministrator Get(int id);
        LeagueAdministrator Delete(int id);
        LeagueAdministrator Add(LeagueAdministrator LeagueAdministrator);
    }
}
