(function () {
    'use strict';

    angular
        .module('tournamentsApp')
        .controller('leaguesController', leaguesController);

    leaguesController.$inject = ['$scope', 'Leagues', 'League'];

    function leaguesController($scope, Leagues, League) {
        $scope.leagues = League.query();
        var league = League.get({ id: 1 }, function () { console.log(league); });
    }
})();
