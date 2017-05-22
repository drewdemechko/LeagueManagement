(function () {
    'use strict';

    var teamService = angular.module('teamService', ['ngResource']);

    teamService.factory('Teams', ['$resource',
        function ($resource) {
            return $resource('/api/Teams/:id');
        }]);
})();