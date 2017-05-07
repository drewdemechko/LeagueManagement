using PersonnelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManager.Services.Contracts
{
    public interface IGuestDomainService
    {
        List<Guest> Get();
        Guest Get(int id);
        Guest Delete(int id);
        Guest Add(Guest Guest);
    }
}
