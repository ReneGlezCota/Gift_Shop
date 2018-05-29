'use strict';

angular
    .module('myApp', [
        'ngAnimate',
        'ngCookies',
        'ngResource',
        'ngRoute',
        'ui.bootstrap'])
    .config(['$httpProvider', '$locationProvider', function ($httpProvider, $locationProvider) {
        //$httpProvider.interceptors.push('xmlHttpInteceptor');
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
}]);