﻿using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentWizard.Models;
using TournamentWizard.Services.Contracts;

namespace TournamentWizard.Controllers
{
    [Route("api/LeagueTournament")]
    public class LeagueTournamentController : Controller
    {
        private ILeagueTournamentService _leagueTournamentService;
        private ILeagueService _leagueService;
        
        public LeagueTournamentController(ILeagueTournamentService leagueTournamentService, ILeagueService leagueService)
        {
            _leagueTournamentService = leagueTournamentService;
            _leagueService = leagueService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var tournaments = _leagueTournamentService.Get();

            if (tournaments == null)
            {
                return HttpNotFound("No tournaments were found.");
            }

            return new JsonResult(tournaments);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            //not a valid id, should only allow integer values
            if (id == 0)
            {
                return HttpBadRequest("Tournament could not be retreived. Tournament id:" + id + " is not a valid tournament id.");
            }

            var tournament = _leagueTournamentService.Get(id);

            if (tournament == null)
            {
                return HttpNotFound("No tournament exists with id:" + id + ".");
            }

            return new JsonResult(tournament);
        }

        [HttpPost]
        public ActionResult Add([Bind("Name")]LeagueTournament tournament, int leagueId)
        {
            LeagueTournament newTournament = null;

            var existingTournament = _leagueTournamentService.Get(tournament.Name);

            var existingLeague = _leagueService.Get(leagueId);

            if (existingLeague == null)
            {
                return HttpBadRequest("A league with that id does not exist.");
            }

            if (existingTournament != null)
            {
                return HttpBadRequest("A tournament already exists with that name.");
            }

            if (ModelState.IsValid)
            {
                tournament.League = existingLeague;
                newTournament = _leagueTournamentService.Add(tournament);
            }

            if (newTournament == null)
            {
                return HttpBadRequest("Tournament creation failed.");
            }

            return new JsonResult(newTournament);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit([Bind("Name")]int id, LeagueTeam team)
        {
            return new JsonResult(new NotImplementedException());
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return HttpBadRequest("Tournament could not be deleted. Tournament id:" + id + " is not a valid tournament id.");
            }

            var tournament = _leagueTournamentService.Get(id);

            if (tournament == null)
            {
                return HttpNotFound("No tournament exists with id:" + id + ".");
            }

            var deletedTournament = _leagueTournamentService.Delete(tournament);

            if (deletedTournament == null)
            {
                return HttpBadRequest("Tournament deletion failed.");
            }

            return new JsonResult(deletedTournament);
        }
    }
}
