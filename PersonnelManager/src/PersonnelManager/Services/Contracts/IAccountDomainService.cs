using PersonnelManager.Models;
using System.Collections.Generic;

namespace PersonnelManager.Services.Contracts
{
    public interface IAccountDomainService
    {
        List<Account> Get();
        Account Get(int id);
        Account Get(string username);
        Account Delete(Account Account);
        Account Update(Account Account);
        Account Add(Account Account);
        Account Login(string username, string hashedPassword);
    }
}
