(function () {
    'use strict';

    var competitorService = angular.module('competitorService', ['ngResource']);

    competitorService.factory('Competitors', ['$resource',
        function ($resource) {
            return $resource('/api/Competitors/:id');
        }]);
})();