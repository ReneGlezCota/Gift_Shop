'use strict';

var myApp = angular.module('myApp')

myApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: '/App/Views/Home/index.html',
        controller: 'HomeController'
    });

}]);
