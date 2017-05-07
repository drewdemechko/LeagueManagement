using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonnelManager.Models;

namespace PersonnelManager.Services
{
    public class OrganizationAdministratorDomainService : IOrganizationAdministratorDomainService
    {
        private AppDbContext database;
        private List<OrganizationAdministrator> organizationAdministrators;

        public OrganizationAdministratorDomainService()
        {
            database = new AppDbContext();
            organizationAdministrators = database.OrganizationAdministrator.ToList();
        }

        public OrganizationAdministrator Add(OrganizationAdministrator OrganizationAdministrator)
        {
            throw new NotImplementedException();
        }

        public OrganizationAdministrator Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrganizationAdministrator> Get()
        {
            return organizationAdministrators.ToList();
        }

        public OrganizationAdministrator Get(int id)
        {
            return organizationAdministrators.Where(oa => oa.Id == id).FirstOrDefault();
        }
    }
}
