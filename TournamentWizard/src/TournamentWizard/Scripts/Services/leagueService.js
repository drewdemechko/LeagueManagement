(function () {
    'use strict';

    var leaguesServices = angular.module('leaguesServices', ['ngResource']);

    leaguesServices.factory('Leagues', ['$resource',
      function ($resource) {
          return $resource('/api/Leagues/', {}, {
              query: { method: 'GET', params: {}, isArray: true }
          });
      }]);

    leaguesServices.factory('League', ['$resource',
        function ($resource) {
            return $resource('/api/Leagues/:id');
        }]);
})();