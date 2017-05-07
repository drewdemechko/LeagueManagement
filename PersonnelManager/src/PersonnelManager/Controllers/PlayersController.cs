using Microsoft.AspNet.Mvc;
using PersonnelManager.Services.Contracts;

namespace PersonnelManager.Controllers
{
    [Route("api/players")]
    public class PlayersController : Controller
    {
        private IPlayerDomainService _playerService;

        public PlayersController(IPlayerDomainService playerService)
        {
            _playerService = playerService;
        }

        //ex:api/players?includeAll=true&withoutAccountsOnly=true&withAccountsOnly=true
        public ActionResult Get(bool withAccountsOnly, bool withoutAccountsOnly)
        {
            var players = _playerService.Get(withAccountsOnly, withoutAccountsOnly);

            if (players == null)
            {
                return HttpNotFound("No players found.");
            }

            return new JsonResult(players);
        }

        [Route("{id}")]
        public ActionResult Get(int id, bool withAccountsOnly, bool withoutAccountsOnly)
        {
            //not a valid id, should only allow integer values
            if (id == 0)
            {
                return HttpBadRequest("Player could not be retreived. Player id:" + id + " is not a valid player id.");
            }

            var players = _playerService.Get(id, withAccountsOnly, withoutAccountsOnly);

            if (players == null)
            {
                return HttpNotFound("No player found with that id.");
            }

            return new JsonResult(players);
        }

        [HttpPost]
        [Route("attach/{accountId}/{playerId}")]
        public ActionResult AttachToAccount(int accountId, int playerId)
        {
            if (accountId == 0 || playerId == 0)
            {
                return HttpBadRequest("PlayerAccount could not be retreived. Either the Account id:" + accountId + " or the Player id: " + playerId + " are not valid.");
            }

            var existingPlayerAccount = _playerService.GetPlayerAccount(accountId, playerId);

            if (existingPlayerAccount != null)
            {
                return HttpBadRequest("The player or account are already attached.");
            }

            var playerAccount = _playerService.AttachToAccount(accountId, playerId);

            if (playerAccount == null)
            {
                return HttpNotFound("Unable to Add PlayerAccount. Either the account with id: " + accountId + " or player with id: " + playerId + " does not exist.");
            }

            return new JsonResult(playerAccount);
        }
    }
}
