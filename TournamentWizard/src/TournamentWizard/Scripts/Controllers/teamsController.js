(function () {
    'use strict';

    angular
        .module('tournamentsApp')
        .controller('teamsController', teamsController);

    teamsController.$inject = ['$scope', 'Teams'];

    function teamsController($scope, Teams) {
        var teams = function () {
            return Teams.query();
        };

        var team = function (id) {
            Teams.get({ id: id }, function () { console.log(team); })
        };
    }
})();
