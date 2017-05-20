(function () {
    'use strict';

    var bracketLayoutService = angular.module('bracketLayoutService', ['ngResource']);

    bracketLayoutService.factory('Brackets', ['$resource',
        function ($resource) {
            return $resource('/api/Brackets/:id');
        }]);
})();