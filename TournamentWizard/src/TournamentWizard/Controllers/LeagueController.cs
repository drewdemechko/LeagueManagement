using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Controllers
{
    [Route("api/League")]
    public class LeagueController : Controller
    {
        private ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var leagues = _leagueService.Get();

            if (leagues == null)
            {
                return HttpNotFound("No leagues were found.");
            }

            return new JsonResult(leagues);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            //not a valid id, should only allow integer values
            if (id == 0)
            {
                return HttpBadRequest("League could not be retreived. League id:" + id + " is not a valid league id.");
            }

            var league = _leagueService.Get(id);

            if (league == null)
            {
                return HttpNotFound("No league exists with id:" + id + ".");
            }

            return new JsonResult(league);
        }

        [HttpPost]
        public ActionResult Add([Bind("Name", "Abbreviation")]League league)
        {
            League newLeague = null;
            var existingLeague = _leagueService.Get(league.Name);

            if (existingLeague != null)
            {
                return HttpBadRequest("A league already exists with that name.");
            }

            if (ModelState.IsValid)
            {
                newLeague = _leagueService.Add(league);
            }

            if (newLeague == null)
            {
                return HttpBadRequest("League creation failed.");
            }

            return new JsonResult(newLeague);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit([Bind("Name", "Abbreviation")]int id, League league)
        {
            //not a valid id, should only allow integer values
            if (id == 0)
            {
                return HttpBadRequest("League could not be edited. League id:" + id + " is not a valid league id.");
            }

            var existingLeague = _leagueService.Get(id);

            if (existingLeague == null)
            {
                return HttpBadRequest("A league with id " + id + " does not exist.");
            }

            var updatedLeague = _leagueService.Update(league);

            if (updatedLeague == null)
            {
                return HttpBadRequest("League update failed.");
            }

            return new JsonResult(updatedLeague);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpBadRequest("League could not be deleted. League id:" + id + " is not a valid league id.");
            }

            var league = _leagueService.Get(id);

            if (league == null)
            {
                return HttpNotFound("No league exists with id:" + id + ".");
            }

            var deletedLeague = _leagueService.Delete(league);

            if (deletedLeague == null)
            {
                return HttpBadRequest("League deletion failed.");
            }

            return new JsonResult(deletedLeague);
        }
    }
}
