using PersonnelManager.Models;
using System.Collections.Generic;

namespace PersonnelManager.Services.Contracts
{
    public interface ICoachDomainService
    {
        List<Coach> Get(bool withAccountsOnly, bool withoutAccountsOnly);
        Coach GetCoach(int accountId);
        Coach Get(int id, bool withAccountsOnly, bool withoutAccountsOnly);
        Coach Delete(int id);
        CoachAccount DeleteAssociatedAccount(Account Account);
        Coach Add(Coach Coach);
        CoachAccount GetCoachAccount(int accountId, int coachId);
        CoachAccount AttachToAccount(int accountId, int coachId);
    }
}
