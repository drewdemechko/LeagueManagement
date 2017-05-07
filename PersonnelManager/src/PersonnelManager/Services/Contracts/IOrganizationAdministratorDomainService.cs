using PersonnelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManager.Services.Contracts
{
    public interface IOrganizationAdministratorDomainService
    {
        List<OrganizationAdministrator> Get();
        OrganizationAdministrator Get(int id);
        OrganizationAdministrator Delete(int id);
        OrganizationAdministrator Add(OrganizationAdministrator OrganizationAdministrator);
    }
}
