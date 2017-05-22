(function () {
    'use strict';

    var leagueService = angular.module('leagueService', ['ngResource']);

    leagueService.factory('Leagues', ['$resource',
        function ($resource) {
            return $resource('/api/Leagues/:id');
        }]);
    leagueService.factory('LeaguesTeams', ['$resource',
        function ($resource) {
            return $resource('/api/Leagues/:leagueId/Teams');
        }]);
})();