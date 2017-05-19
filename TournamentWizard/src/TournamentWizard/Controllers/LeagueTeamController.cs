using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Controllers
{
    [Route("api/Teams")]
    public class LeagueTeamController : Controller
    {
        private ILeagueService _leagueService;
        private ITeamService _teamService;

        public LeagueTeamController(ILeagueService leagueService, ITeamService teamService)
        {
            _leagueService = leagueService;
            _teamService = teamService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var teams = _teamService.Get();

            if (teams == null)
            {
                return HttpNotFound("No teams were found.");
            }

            return new JsonResult(teams);
        }

        [HttpPost]
        public ActionResult Add([Bind("Name", "Nickname")]LeagueTeam team, int leagueId)
        {
            LeagueTeam newTeam = null;
            var existingTeam = _teamService.Get(team.Name, leagueId);

            var existingLeague = _leagueService.Get(leagueId);

            if(existingLeague == null)
            {
                return HttpBadRequest("A league with that id does not exist.");
            }

            if (existingTeam != null)
            {
                return HttpBadRequest("A team in that league already exists with that name.");
            }

            if (ModelState.IsValid)
            {
                team.League = existingLeague;
                newTeam = _teamService.Add(team);
            }

            if (newTeam == null)
            {
                return HttpBadRequest("Team creation failed.");
            }

            return new JsonResult(newTeam);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit([Bind("Name", "Nickname")]int id, LeagueTeam team)
        {
            return new JsonResult(new NotImplementedException());
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpBadRequest("Team could not be deleted. Team id:" + id + " is not a valid team id.");
            }

            var team = _teamService.Get(id);

            if (team == null)
            {
                return HttpNotFound("No team exists with id:" + id + ".");
            }

            var deletedTeam = _teamService.Delete(team);

            if (deletedTeam == null)
            {
                return HttpBadRequest("Team deletion failed.");
            }

            return new JsonResult(deletedTeam);
        }
    }
}
