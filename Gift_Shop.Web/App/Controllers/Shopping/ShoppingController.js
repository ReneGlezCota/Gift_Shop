'use strict';

angular
    .module('myApp')
    .controller('ShoppingController', ['$scope', '$window', '$filter', '$uibModal', 'ShoppingService', function ($scope, $window, $filter, $uibModal, ShoppingService) {
        
        $scope.products = ShoppingService.getProducts();
        console.log($scope.products);

        ////Function to get all products
        //var initProduct = function () {
        //    $scope.promiseProduct = ProductService.getAllProducts().then(function (result) {
        //        $scope.products = result.data;
        //        $scope.filteredItems = result.data;

        //        initializePagination(result.data);
        //    });
        //};

        

        ////Charge the all values
        //initProduct();

       
    }]);
