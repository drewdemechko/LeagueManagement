(function () {
    'use strict';

    angular
        .module('tournamentsApp')
        .controller('bracketLayoutsController', bracketLayoutsController);

    bracketLayoutsController.$inject = ['$scope', 'Brackets'];

    function bracketLayoutsController($scope, Brackets) {
        var brackets = function () {
            return Brackets.query();
        };

        var bracket = function (id) {
            Brackets.get({ id: id }, function () { console.log(bracket); })
        };
    }
})();
