'use strict';

angular
    .module('myApp', [
        'ngAnimate',
        'ngCookies',
        'ngResource',
        'ngSanitize',
        'ui.bootstrap',
        'ui.router'])
    .config(['$httpProvider', '$locationProvider', function ($httpProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
}]);