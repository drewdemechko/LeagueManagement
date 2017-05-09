using Microsoft.AspNet.Mvc;
using PersonnelManager.Services.Contracts;

namespace PersonnelManager.Controllers
{
    [Route("api/coaches")]
    public class CoachesController : Controller
    {
        private ICoachDomainService _coachService;

        public CoachesController(ICoachDomainService coachService)
        {
            _coachService = coachService;
        }

        //ex:api/coaches?withAccountsOnly=true&withoutAccountsOnly=true
        public ActionResult Get(bool withAccountsOnly, bool withoutAccountsOnly)
        {
            var coaches = _coachService.Get(withAccountsOnly, withoutAccountsOnly);

            if (coaches == null)
            {
                return HttpNotFound("No coaches found.");
            }

            return new JsonResult(coaches);
        }

        [Route("{id}")]
        public ActionResult Get(int id, bool withAccountsOnly, bool withoutAccountsOnly)
        {
            //not a valid id, should only allow integer values
            if (id == 0)
            {
                return HttpBadRequest("Coach could not be retreived. Coach id:" + id + " is not a valid coach id.");
            }

            var coaches = _coachService.Get(id, withAccountsOnly, withoutAccountsOnly);

            if (coaches == null)
            {
                return HttpNotFound("No coach found with that id.");
            }

            return new JsonResult(coaches);
        }

        [HttpPost]
        [Route("attach/{accountId}/{coachId}")]
        public ActionResult AttachToAccount(int accountId, int coachId)
        {
            if(accountId == 0 || coachId == 0)
            {
                return HttpBadRequest("CoachAccount could not be retreived. Either the Account id:" + accountId + " or the Coach id: " + coachId + " are not valid.");
            }

            var existingCoachAccount = _coachService.GetCoachAccount(accountId, coachId);

            if(existingCoachAccount != null)
            {
                return HttpBadRequest("The coach or account are already attached.");
            }

            var coachAccount = _coachService.AttachToAccount(accountId, coachId);

            if(coachAccount == null)
            {
                return HttpNotFound("Unable to Add CoachAccount. Either the account with id: " + accountId + " or coach with id: " + coachId + " does not exist.");
            }

            return new JsonResult(coachAccount);
        }
    }
}
