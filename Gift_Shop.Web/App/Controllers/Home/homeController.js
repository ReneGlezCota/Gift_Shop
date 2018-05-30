'use strict';

angular
    .module('myApp')
    .controller('HomeController', ['$scope', '$window', '$filter', 'ProductService', 'CategoryService', function ($scope, $window, $filter, ProductService, CategoryService) {

        $scope.category = '';
        $scope.categories = '';
        $scope.products = '';
   
        var initProduct = function () {
            $scope.promiseProduct = ProductService.getAllProducts().then(function (result) {
                $scope.products = result.data;
            });
        };

        var initCategories = function () {
            $scope.promiseCategory = CategoryService.getAllCategories().then(function (result) {
                $scope.categories = result.data;
                if ($scope.categories != null) {
                    $scope.categories.push({
                        CategoryID: 0,
                        Name: 'All',
                        Products : null
                    })
                    $scope.category = $scope.categories[1];
                }
            });
        };

        initProduct();
        initCategories();

        $scope.filterByCategory = function (value) {
            //$scope.promiseProduct = ProductService.getProductByCategory(value).then(function (result) {
            //    $scope.products = result.data;
            //});
            console.log(value);
        };
}]);
