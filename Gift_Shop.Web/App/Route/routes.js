'use strict';

angular
    .module('myApp')
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: '/App/Views/Home/index.html',
            controller: 'HomeController'
        });
}]);
