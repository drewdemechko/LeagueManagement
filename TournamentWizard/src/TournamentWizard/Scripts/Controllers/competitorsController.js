(function () {
    'use strict';

    angular
        .module('tournamentsApp')
        .controller('competitorsController', competitorsController);

    competitorsController.$inject = ['$scope', 'Competitors'];

    function competitorsController($scope, Competitors) {
        var competitors = function () {
            return Competitors.query();
        };

        var competitor = function (id) {
            Competitors.get({ id: id }, function () { console.log(competitor); })
        };
    }
})();
