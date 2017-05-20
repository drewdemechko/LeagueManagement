(function () {
    'use strict';

    var leaguesService = angular.module('tournamentService', ['ngResource']);

    tournamentsService.factory('Tournaments', ['$resource',
        function ($resource) {
            return $resource('/api/LeagueTournaments/:id');
        }]);
})();