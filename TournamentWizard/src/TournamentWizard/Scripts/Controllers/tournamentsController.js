(function () {
    'use strict';

    angular
        .module('tournamentsApp')
        .controller('tournamentsController', tournamentsController);

    tournamentsController.$inject = ['$scope', 'LeagueTournaments']; 

    function tournamentsController($scope, LeagueTournaments) {
        var leagueTournaments = function () {
            return LeagueTournaments.query();
        };

        var leagueTournament = function (id) {
            LeagueTournaments.get({ id: id }, function () { console.log(leagueTournament); })
        };
    }
})();
