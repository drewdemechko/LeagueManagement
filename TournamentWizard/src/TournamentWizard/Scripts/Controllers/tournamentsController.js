(function () {
    'use strict';

    angular
        .module('tournamentsApp')
        .controller('tournamentsController', tournamentsController);

    tournamentsController.$inject = ['$scope', 'LeagueTournaments', 'LeagueTournamentBrackets', 'LeagueTournamentCompetitors']; 

    function tournamentsController($scope, LeagueTournaments, LeagueTournamentBrackets, LeagueTournamentCompetitors) {
        var leagueTournaments = function () {
            return LeagueTournaments.query();
        };

        var leagueTournament = function (id) {
            LeagueTournaments.get({ id: id }, function () { console.log(leagueTournament); })
        };

        var bracketsFromLeagueTournament = function (tournamentId) {
            return LeagueTournamentBrackets.query({ tournamentId: tournamentId });
        };

        var competitorsFromLeagueTournament = function (tournamentId) {
            return LeagueTournamentCompetitors.query({ tournamentId: tournamentId });
        };
    }
})();
