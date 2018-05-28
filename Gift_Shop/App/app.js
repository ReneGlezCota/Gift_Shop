'use strict';

var myApp = angular.module('myApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ui.bootstrap'
]);

myApp.config(['$httpProvider', '$locationProvider', function ($httpProvider, $locationProvider) {
    //$httpProvider.interceptors.push('xmlHttpInteceptor');
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);