using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using PersonnelManager.Models;
using Microsoft.Data.Entity;

namespace PersonnelManager.Services
{
    public class AccountDomainService : IAccountDomainService
    {
        private AppDbContext database;
        private List<Account> accounts;

        public AccountDomainService()
        {
            database = new AppDbContext();
            accounts = database.Account.AsNoTracking().ToList();
        }

        public Account Add(Account Account)
        {
            database.Account.Add(Account);
            database.SaveChanges();
            return Account;
        }

        public Account Delete(Account Account)
        {
            //first - delete all account types associated with account to be deleted
            //DeleteAssociatedAccountTypes(Account);
                       
            database.Account.Remove(Account);
            database.SaveChanges();
            return Account;
        }

        public Account Update(Account Account)
        {
            var oldAccount = Get(Account.Id);
            var newAccount = Account;

            if (areEqual(oldAccount,newAccount))
            {
                return oldAccount;
            }

            database.Account.Update(Account);
            database.SaveChanges();
            return Account;
        }

        public Account Get(int id)
        {
            return accounts.Where(a => a.Id == id).FirstOrDefault();
        }

        public Account Get(string username)
        {
            return accounts.Where(a => a.Username == username).FirstOrDefault();
        }

        public List<Account> Get()
        {
            return accounts;
        }

        public Account Login(string username, string hashedPassword)
        {
            throw new NotImplementedException();
        }

        public static bool isValidUsername(string username)
        {
            return true;
        }

        public static bool isValidPassword(string unhashedPassword)
        {
            return true;
        }

        public static string hashedPassword(string unhashedPassword)
        {
            return "";
        }

        private static bool areEqual(Account a, Account b)
        {
            return a.Username == b.Username && a.Password == b.Password;
        }
    }
}
