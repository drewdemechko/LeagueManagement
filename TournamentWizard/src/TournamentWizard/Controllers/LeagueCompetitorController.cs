using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Controllers
{
    [Route("api/Competitor")]
    public class LeagueCompetitorController : Controller
    {
        private ICompetitorService _competitorService;
        private ITeamService _teamService;
        private ILeagueTournamentService _tournamentService;

        public LeagueCompetitorController(ICompetitorService competitorService, ITeamService teamService, 
            ILeagueTournamentService tournamentService)
        {
            _competitorService = competitorService;
            _teamService = teamService;
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var competitors = _competitorService.Get();

            if (competitors == null)
            {
                return HttpNotFound("No competitors were found.");
            }

            return new JsonResult(competitors);
        }

        [HttpPost]
        public ActionResult Add(int teamId, int tournamentId)
        {
            LeagueCompetitor newCompetitor = null;
            var existingCompetitor = _competitorService.Get(teamId, tournamentId);

            var existingTeam = _teamService.Get(teamId);

            if (existingTeam == null)
            {
                return HttpBadRequest("A team with that id does not exist.");
            }

            var existingTournament = _tournamentService.Get(tournamentId);

            if(existingTournament == null)
            {
                return HttpBadRequest("A tournament with that id does not exist.");
            }

            if (existingCompetitor != null)
            {
                return HttpBadRequest("A competitor with that team already exists for that tournament.");
            }

            if (ModelState.IsValid)
            {
                newCompetitor.Team = existingTeam;
                newCompetitor.Tournament = existingTournament;
                newCompetitor = _competitorService.Add(newCompetitor);
            }

            if (newCompetitor == null)
            {
                return HttpBadRequest("Competitor creation failed.");
            }

            return new JsonResult(newCompetitor);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, int teamId, int tournamentId)
        {
            return new JsonResult(new NotImplementedException());
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpBadRequest("Competitor could not be deleted. Competitor id:" + id + " is not a valid competitor id.");
            }

            var competitor = _competitorService.Get(id);

            if (competitor == null)
            {
                return HttpNotFound("No competitor exists with id:" + id + ".");
            }

            var deletedCompetitor = _competitorService.Delete(competitor);

            if (deletedCompetitor == null)
            {
                return HttpBadRequest("Competitor deletion failed.");
            }

            return new JsonResult(deletedCompetitor);
        }
    }
}
