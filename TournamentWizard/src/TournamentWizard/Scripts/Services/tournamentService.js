(function () {
    'use strict';

    var tournamentService = angular.module('tournamentService', ['ngResource']);

    tournamentService.factory('Tournaments', ['$resource',
        function ($resource) {
            return $resource('/api/LeagueTournaments/:id');
        }]);

    tournamentService.factory('LeagueTournamentBrackets', ['$resource',
        function ($resource) {
            return $resource('/api/LeagueTournaments/:tournamentId/Bracket');
        }]);

    tournamentService.factory('LeagueTournamentCompetitors', ['$resource',
        function ($resource) {
            return $resource('/api/LeagueTournaments/:tournamentId/Competitors');
        }]);
})();