!function(){"use strict";angular.module("moviesApp",["moviesServices"])}(),function(){"use strict";function a(a,b){a.movies=b.query()}angular.module("moviesApp").controller("moviesController",a),a.$inject=["$scope","Movies"]}(),function(){"use strict";angular.module("moviesServices",["ngResource"]).factory("Movies",["$resource",function(a){return a("/api/League/",{},{query:{method:"GET",params:{},isArray:!0}})}])}();