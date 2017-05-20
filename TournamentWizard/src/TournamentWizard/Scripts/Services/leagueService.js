(function () {
    'use strict';

    var leaguesService = angular.module('leagueService', ['ngResource']);

    leaguesService.factory('Leagues', ['$resource',
        function ($resource) {
            return $resource('/api/Leagues/:id');
        }]);
})();