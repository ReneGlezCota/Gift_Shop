'use strict';

var myApp = angular.module('myApp');

myApp.controller('HomeController', ['$scope', '$window', '$filter', 'ProductService', function ($scope, $window, $filter, ProductService) {

    $scope.hola = 'das';

    var initProduct = function () {
        $scope.promiseProduct = ProductService.getAllProducts().then(function (result) {
            $scope.products = result.data.data;
            $scope.filteredItems = result.data.data;
        });
    };

    initProduct();
}]);
