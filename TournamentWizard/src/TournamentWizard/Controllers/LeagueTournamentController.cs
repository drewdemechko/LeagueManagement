using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Controllers
{
    [Route("api/LeagueTournaments")]
    public class LeagueTournamentController : Controller
    {
        private ILeagueTournamentService _leagueTournamentService;
        
        public LeagueTournamentController(ILeagueTournamentService leagueTournamentService)
        {
            _leagueTournamentService = leagueTournamentService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult("");
        }
    }
}
