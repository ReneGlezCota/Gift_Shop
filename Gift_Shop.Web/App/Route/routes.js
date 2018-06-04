'use strict';

angular
    .module('myApp')
    .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/home');
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
}]);
