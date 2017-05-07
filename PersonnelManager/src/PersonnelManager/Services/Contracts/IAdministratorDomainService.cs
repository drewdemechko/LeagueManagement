using PersonnelManager.Models;
using System.Collections.Generic;

namespace PersonnelManager.Services.Contracts
{
    public interface IAdministratorDomainService
    {
        List<Administrator> Get();
        Administrator Get(int id);
        Administrator Delete(int id);
        Administrator Add(Administrator Administrator);
        Administrator Update(Administrator Administrator);
    }
}
