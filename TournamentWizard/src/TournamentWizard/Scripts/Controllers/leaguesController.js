(function () {
    'use strict';

    angular
        .module('tournamentsApp')
        .controller('leaguesController', leaguesController);

    leaguesController.$inject = ['$scope', 'Leagues'];

    function leaguesController($scope, Leagues) {
        $scope.leagues = Leagues.query();
        var leagues = function () {
            return Leagues.query();
        };

        var league = function (id) {
            Leagues.get({ id: id }, function () { console.log(league); })
        };
    }
})();
