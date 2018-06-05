'use strict';

angular
    .module('myApp')
    .config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {
        
        $stateProvider
            .state('home', {
                url: '/home',
                templateUrl: '/App/Views/Home/index.html',
                controller: 'HomeController'
            })
            .state('shopping', {
                url: '/shopping',
                templateUrl: '/App/Views/Shopping/index.html',
                controller: 'ShoppingController'
            })
            .state('product', {
                url: '/product',
                templateUrl: '/App/Views/Product/index.html',
                controller : 'ProductController'
            });

        $urlRouterProvider.otherwise('/App/Views/');        
        $locationProvider.html5Mode({ enabled: true, requireBase: false });
}]);
