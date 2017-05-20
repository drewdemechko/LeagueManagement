(function () {
    'use strict';

    var leaguesService = angular.module('teamService', ['ngResource']);

    leaguesService.factory('Teams', ['$resource',
        function ($resource) {
            return $resource('/api/Teams/:id');
        }]);
})();