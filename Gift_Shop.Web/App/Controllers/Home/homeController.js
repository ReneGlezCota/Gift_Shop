'use strict';

angular
    .module('myApp')
    .controller('HomeController', ['$scope', '$window', '$filter', 'ProductService', function ($scope, $window, $filter, ProductService) {

        $scope.products = '';
   
        var initProduct = function () {
            $scope.promiseProduct = ProductService.getAllProducts().then(function (result) {
                $scope.products = result.data;
            });
        };


        initProduct();
}]);
