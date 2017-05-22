(function () {
    'use strict';

    var app = angular.module('tournamentsApp', [
        'leagueService', 'tournamentService', 'teamService', 'competitorService', 'bracketLayoutService',
        'ngRoute'
    ]);
    app.config(["$routeProvider", function ($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: 'main.html'
        })
        .otherwise({
            redirectTo: '/'
        });
    }]);
})();