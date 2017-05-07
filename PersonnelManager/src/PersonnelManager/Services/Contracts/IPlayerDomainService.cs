using PersonnelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelManager.Services.Contracts
{
    public interface IPlayerDomainService
    {
        List<Player> Get(bool withAccountsOnly, bool withoutAccountsOnly);
        Player GetPlayer(int accountId);
        Player Get(int id, bool withAccountsOnly, bool withoutAccountsOnly);
        Player Delete(int id);
        PlayerAccount DeleteAssociatedAccount(Account Account);
        Player Add(Player Player);
        PlayerAccount GetPlayerAccount(int accountId, int playerId);
        PlayerAccount AttachToAccount(int accountId, int playerId);
    }
}
