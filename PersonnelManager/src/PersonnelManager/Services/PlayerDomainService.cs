using PersonnelManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonnelManager.Models;
using Microsoft.Data.Entity;

namespace PersonnelManager.Services
{
    public class PlayerDomainService : IPlayerDomainService
    {
        private AppDbContext database;
        private List<Player> players;
        private List<PlayerAccount> playerAccounts;
        private IAccountDomainService _accountService;

        public PlayerDomainService(IAccountDomainService accountService)
        {
            database = new AppDbContext();
            players = database.Player.AsNoTracking().ToList();
            playerAccounts = database.PlayerAccount
                .Include(pa => pa.Account)
                .Include(pa => pa.Player)
                .AsNoTracking().ToList();
            _accountService = accountService;
    }

        public Player Add(Player Player)
        {
            database.Player.Add(Player);
            database.SaveChanges();
            return Player;
        }

        public Player Update(Player Player)
        {
            var oldPlayer = Get(Player.Id);
            var newPlayer = Player;

            if (areEqual(oldPlayer, newPlayer))
            {
                return oldPlayer;
            }

            database.Player.Update(Player);
            database.SaveChanges();
            return Player;
        }

        public Player Delete(int id)
        {
            var player = Get(id, true, false);

            if (player == null)
            {
                return null;
            }

            database.Player.Remove(player);
            database.SaveChanges();
            return player;
        }

        public PlayerAccount DeleteAssociatedAccount(Account Account)
        {
            var playerAccountToDelete = playerAccounts.Where(pa => pa.Account.Id == Account.Id).FirstOrDefault();

            if (playerAccountToDelete == null)
            {
                return null;
            }

            //delete foreign entity with foreign keys first!
            database.PlayerAccount.Remove((PlayerAccount)playerAccountToDelete);
            database.SaveChanges();

            return playerAccountToDelete;
        }

        public List<Player> Get(bool withAccountsOnly = false, bool withoutAccountsOnly = false)
        {
            if (withAccountsOnly)
                return GetPlayersWithAccounts();
            else if (withoutAccountsOnly)
                return GetPlayersWithoutAccounts();
            else
                return players;
        }

        public Player Get(int id, bool withAccountsOnly = false, bool withoutAccountsOnly = false)
        {
            var players = Get(withAccountsOnly, withoutAccountsOnly);
            return players.Where(p => p.Id == id).FirstOrDefault();
        }

        private List<Player> GetPlayersWithoutAccounts()
        {
            var playerAccountsIds = new HashSet<int>(playerAccounts.Select(pa => pa.Player.Id));
            var playersWithoutAccounts = players.Where(p => !playerAccountsIds.Contains(p.Id)).ToList();

            return playersWithoutAccounts;
        }

        private List<Player> GetPlayersWithAccounts()
        {
            return playerAccounts.Select(pa => pa.Player).ToList();
        }

        public Player GetPlayer(int accountId)
        {
            var playerId = playerAccounts.Where(ca => ca.Account.Id == accountId).Select(ca => ca.Player.Id).FirstOrDefault();
            return players.Where(p => p.Id == playerId).FirstOrDefault();
        }

        public PlayerAccount GetPlayerAccount(int accountId, int playerId)
        {
            var existingPlayerAccount = playerAccounts.Where(pa => pa.Account.Id == accountId || pa.Player.Id == playerId).FirstOrDefault();

            return existingPlayerAccount;
        }

        public PlayerAccount AttachToAccount(int accountId, int playerId)
        {
            PlayerAccount newPlayerAccount = new PlayerAccount();

            var account = _accountService.Get(accountId);
            var player = Get(playerId);

            if (account == null || player == null)
            {
                return null; //account or player does not exist
            }

            newPlayerAccount.Account = account;
            newPlayerAccount.Player = player;

            database.PlayerAccount.Add(newPlayerAccount);
            database.SaveChanges();
            return newPlayerAccount;
        }

        private static bool areEqual(Player a, Player b)
        {
            return a.FirstName == b.FirstName && a.LastName == b.LastName;
        }
    }
}
