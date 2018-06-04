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
                        if (_(r['Name']).toString().toUpperCase().includes($scope.productname.toString().toUpperCase())) { return true; };                        
                        return false;
                    }
                ).value();

                $scope.filteredItems = obj;
            };
        }

        $scope.updateItem = function (value) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Modals/productUpdate.html',
                controller: 'ModalUpdateProductController',
                resolve: {
                    details: function () {
                        return value;
                    }
                }
            });

            modalInstance.result.then(function (values) {
                initProduct();
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });       
        };

        $scope.deleteItem = function (value) {        
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Modals/productDelete.html',
                controller: 'ModalDeleteProductController',
                resolve: {
                    details: function () {
                        return value;
                    }
                }
            });

            modalInstance.result.then(function (values) {
                initProduct();
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });       
        };
    }])
    .controller('ModalUpdateProductController', function ($scope, $uibModalInstance, details, ProductService, CategoryService) {
        console.log(details);
        $scope.details = details;
        $scope.promiseUpdate = '';
        $scope.categories = '';

        var initCategories = function () {
            $scope.promiseCategory = CategoryService.getAllCategories().then(function (result) {
                $scope.categories = result.data;
                if ($scope.categories != null) {
                    $scope.category = details.CategoryID;
                }
            });
        };

        initCategories();

        $scope.update = function () {
            //$scope.promiseDelete = ProductService.updateProduct($scope.details.ProductID).then(function (result) {
            //    $uibModalInstance.close(result.data);
            //});
        };

        $scope.closeUpdate = function () {
            $uibModalInstance.close();
        };
    })
    .controller('ModalDeleteProductController', function ($scope, $uibModalInstance, details, ProductService) {
        console.log(details);
        $scope.details = details;
        $scope.promiseDelete = '';

        $scope.deleteProduct = function () {
            //$scope.promiseDelete = ProductService.deleteProduct($scope.details.ProductID).then(function (result) {
            //    $uibModalInstance.close(result.data);
            //});
        };  

        $scope.closeDetails = function () {
            $uibModalInstance.close();
        };
    });
