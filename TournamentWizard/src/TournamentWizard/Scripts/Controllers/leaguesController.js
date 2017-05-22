(function () {
    'use strict';

    angular
        .module('tournamentsApp')
        .controller('leaguesController', leaguesController);

    leaguesController.$inject = ['$scope', 'Leagues', 'LeaguesTeams'];

    function leaguesController($scope, Leagues, LeaguesTeams) {
        var leagues = function () {
            return Leagues.query();
        };

        var league = function (id) {
            return Leagues.get({ id: id });
        };

        var teamsFromLeague = function (leagueId) {
            return LeaguesTeams.query({ leagueId: leagueId });
        };

        $scope.leagues = teamsFromLeague(1);
    }
})();
