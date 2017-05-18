using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Controllers
{
    [Route("api/Bracket")]
    public class LeagueBracketController : Controller
    {
        private ICompetitorService _competitorService;
        private ILeagueTournamentService _tournamentService;
        private IBracketLayoutService _bracketService;

        public LeagueBracketController(ICompetitorService competitorService, ILeagueTournamentService tournamentService,
            IBracketLayoutService bracketService)
        {
            _competitorService = competitorService;
            _tournamentService = tournamentService;
            _bracketService = bracketService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var brackets = _bracketService.Get();

            if (brackets == null)
            {
                return HttpNotFound("No brackets were found.");
            }

            return new JsonResult(brackets);
        }

        [HttpPost]
        public ActionResult Add(int competitorId, int tournamentId)
        {
            LeagueTournamentLine newLine = null;
            var existingLine = _bracketService.Get(competitorId, tournamentId);

            var existingCompetitor = _competitorService.Get(competitorId);

            if (existingCompetitor == null)
            {
                return HttpBadRequest("A competitor with that id does not exist.");
            }

            var existingTournament = _tournamentService.Get(tournamentId);

            if (existingTournament == null)
            {
                return HttpBadRequest("A tournament with that id does not exist.");
            }

            if (existingLine != null)
            {
                return HttpBadRequest("A line on that tournament already exists for that team.");
            }

            if (ModelState.IsValid)
            {
                newLine.Competitor = existingCompetitor;
                newLine.Tournament = existingTournament;
                newLine = _bracketService.Add(newLine);
            }

            if (newLine == null)
            {
                return HttpBadRequest("Tournament Line creation failed.");
            }

            return new JsonResult(newLine);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, int competitorId, int tournamentId)
        {
            return new JsonResult(new NotImplementedException());
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpBadRequest("Tournament Line could not be deleted. Tournament line id:" + id 
                    + " is not a valid tournament line id.");
            }

            var line = _bracketService.Get(id);

            if (line == null)
            {
                return HttpNotFound("No tournament line exists with id:" + id + ".");
            }

            var deletedLine = _bracketService.Delete(line);

            if (deletedLine == null)
            {
                return HttpBadRequest("Tournament line deletion failed.");
            }

            return new JsonResult(deletedLine);
        }
    }
}
