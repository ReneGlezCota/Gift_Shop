'use strict';

angular
    .module('myApp')
    .controller('ProductController', ['$scope', '$window', '$filter', '$uibModal', '$state', 'ProductService', function ($scope, $window, $filter, $uibModal, $state, ProductService) {
        $scope.filteredItems = '';
        //Function to get all products
        var initProduct = function () {
            $scope.promiseProduct = ProductService.getAllProducts().then(function (result) {
                $scope.products = result.data;                 
            });
        };

        initProduct();

        $scope.searchProduct = function () {
            if ($scope.productname != '') {
                var obj = _($scope.products).filter(
                    function (r) {
                        for (var key in r) {
                            if (_(r[key]).toString().toUpperCase().includes($scope.productname.toString().toUpperCase())) { return true; };
                        }
                        return false;
                    }
                ).value();

                $scope.filteredItems = obj;
            };

            console.log($scope.filteredItems);

        }
        

    }]);
