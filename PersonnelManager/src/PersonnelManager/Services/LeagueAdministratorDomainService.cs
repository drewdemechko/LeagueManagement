using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonnelManager.Models;

namespace PersonnelManager.Services
{
    public class LeagueAdministratorDomainService : ILeagueAdministratorDomainService
    {
        private AppDbContext database;
        private List<LeagueAdministrator> leagueAdministrators;

        public LeagueAdministratorDomainService()
        {
            database = new AppDbContext();
            leagueAdministrators = database.LeagueAdministrator.ToList();
        }

        public LeagueAdministrator Add(LeagueAdministrator LeagueAdministrator)
        {
            throw new NotImplementedException();
        }

        public LeagueAdministrator Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LeagueAdministrator> Get()
        {
            return leagueAdministrators.ToList();
        }

        public LeagueAdministrator Get(int id)
        {
            return leagueAdministrators.Where(la => la.Id == id).FirstOrDefault();
        }
    }
}
