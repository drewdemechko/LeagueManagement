using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonnelManager.Models;
using Microsoft.Data.Entity;

namespace PersonnelManager.Services
{
    public class CoachDomainService : ICoachDomainService
    {
        private AppDbContext database;
        private List<Coach> coaches;
        private List<CoachAccount> coachAccounts;
        private IAccountDomainService _accountService;

        public CoachDomainService(IAccountDomainService accountService)
        {
            database = new AppDbContext();
            coaches = database.Coach.AsNoTracking().ToList();
            coachAccounts = database.CoachAccount
                .Include(ca => ca.Coach)
                .Include(ca => ca.Account)
                .AsNoTracking().ToList();
            _accountService = accountService;
        }

        public Coach Add(Coach Coach)
        {
            database.Coach.Add(Coach);
            database.SaveChanges();
            return Coach;
        }

        public Coach Update(Coach Coach)
        {
            var oldCoach = Get(Coach.Id);
            var newCoach = Coach;

            if (areEqual(oldCoach, newCoach))
            {
                return oldCoach;
            }

            database.Coach.Update(Coach);
            database.SaveChanges();
            return Coach;
        }

        public Coach Delete(int id)
        {
            var coach = Get(id, true, false);

            if(coach == null)
            {
                return null;
            }

            database.Coach.Remove(coach);
            database.SaveChanges();
            return coach;
        }

        public CoachAccount DeleteAssociatedAccount(Account Account)
        {
            var coachAccountToDelete = coachAccounts.Where(ca => ca.Account.Id == Account.Id).FirstOrDefault();

            if(coachAccountToDelete == null)
            {
                return null;
            }

            //delete foreign entity with foreign keys first!
            database.CoachAccount.Remove((CoachAccount)coachAccountToDelete);
            database.SaveChanges();

            return coachAccountToDelete;
        }

        public List<Coach> Get(bool withAccountsOnly = false, bool withoutAccountsOnly = false)
        {
            if (withAccountsOnly)
                return GetCoachesWithAccounts();
            else if (withoutAccountsOnly)
                return GetCoachesWithoutAccounts();
            else
                return coaches;
        }

        public Coach Get(int id, bool withAccountsOnly = false, bool withoutAccountsOnly = false)
        {
            var coaches = Get(withAccountsOnly, withoutAccountsOnly);
            return coaches.Where(c => c.Id == id).FirstOrDefault();
        }

        private List<Coach> GetCoachesWithoutAccounts()
        {
            var coachAccountsIds = new HashSet<int>(coachAccounts.Select(ca => ca.Coach.Id));
            var coachesWithoutAcounts = coaches.Where(c => !coachAccountsIds.Contains(c.Id)).ToList();

            return coachesWithoutAcounts;
        }

        private List<Coach> GetCoachesWithAccounts()
        {
            return coachAccounts.Select(ca => ca.Coach).ToList();
        }

        public Coach GetCoach(int accountId)
        {
            var coachId = coachAccounts.Where(ca => ca.Account.Id == accountId).Select(ca => ca.Coach.Id).FirstOrDefault();
            return coaches.Where(c => c.Id == coachId).FirstOrDefault();
        }

        public CoachAccount GetCoachAccount(int accountId, int coachId)
        {
            var existingCoachAccount = coachAccounts.Where(ca => ca.Account.Id == accountId || ca.Coach.Id == coachId).FirstOrDefault();

            return existingCoachAccount;
        }

        public CoachAccount AttachToAccount(int accountId, int coachId)
        {
            CoachAccount newCoachAccount = new CoachAccount();

            var account = _accountService.Get(accountId);
            var coach = Get(coachId);

            if (account == null || coach == null)
            {
                return null; //account or coach does not exist
            }

            newCoachAccount.Account = account;
            newCoachAccount.Coach = coach;

            database.CoachAccount.Add(newCoachAccount);
            database.SaveChanges();
            return newCoachAccount;
        }

        private static bool areEqual(Coach a, Coach b)
        {
            return a.FirstName == b.FirstName && a.LastName == b.LastName;
        }
    }
}
