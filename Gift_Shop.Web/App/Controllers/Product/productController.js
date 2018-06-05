'use strict';

angular
    .module('myApp')
    .controller('ProductController', ['$scope', '$window', '$filter', '$uibModal', '$state', 'ProductService', function ($scope, $window, $filter, $uibModal, $state, ProductService) {
        $scope.filteredItems = '';
        $scope.products = '';

        //Function to get all products
        var initProduct = function () {
             ProductService.getAllProducts().then(function (result) {
                 $scope.products = result.data;

                 filterList();
            });
        };

        initProduct();

        $scope.searchProduct = function () {            
            filterList();
        }

        $scope.newProduct = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Modals/productAdd.html',
                controller: 'ModalAddProductController',                
            });

            modalInstance.result.then(function (values) {
                initProduct();
            });
        };

        $scope.returnPage = function () {
            $state.go('home');
        };

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

            modalInstance.result.finally(function (result) {
                initProduct();                
            });
        };

        //Filter product list
        var filterList = function () {
            if ($scope.productname) {
                var obj = _($scope.products).filter(
                    function (r) {
                        if (_(r['Name']).toString().toUpperCase().includes($scope.productname.toString().toUpperCase())) { return true; };
                        return false;
                    }
                ).value();

                $scope.filteredItems = obj;
            }
            else {
                $scope.filteredItems = '';
            }            
        };
    }])
    .controller('ModalAddProductController', function ($scope, $uibModalInstance, ProductService, CategoryService) {
        $scope.categories = '';        
        $scope.details = {
            ProductName: '',
            ProductPrice: '',
            ProductCategoryID: '',
            ProductDescription: ''
        };

        var initCategories = function () {
            $scope.promiseCategory = CategoryService.getAllCategories().then(function (result) {
                $scope.categories = result.data;
                if ($scope.categories != null) {                    
                    $scope.details.ProductCategoryID = $scope.categories[0].Name;
                }
            });
        };

        initCategories();

        $scope.add = function () {
            if ($scope.form.productForm.$valid) {
                $scope.details.ProductCategoryID = _.find($scope.categories, { Name: $scope.details.ProductCategoryID }).CategoryID;
                $scope.promiseProductAdd =  ProductService.addProduct($scope.details).then(function (result) {
                    if (result.data == "OK") {
                        $uibModalInstance.close(result.data);
                    }
                });
            } else {
                console.log('userform is not in scope');
            }
        };

        $scope.closeAdd = function () {
            $uibModalInstance.close();
        };
    })
    .controller('ModalUpdateProductController', function ($scope, $uibModalInstance, details, ProductService, CategoryService) {        
        $scope.details = null;
        console.log(details);
        $scope.details = {
            ProductID : details.ProductID,
            ProductName: details.Name,
            ProductPrice: details.Price,
            ProductCategoryID: details.CategoryID,
            ProductDescription: details.Description,
            ProductImagePath: details.ImagePath
        };
        $scope.categories = '';

        var initCategories = function () {
            $scope.promiseCategory = CategoryService.getAllCategories().then(function (result) {
                $scope.categories = result.data;
                if ($scope.categories != null) {                    
                    var defaultCategory = _.find($scope.categories, { CategoryID: details.CategoryID });
                    $scope.details.ProductCategoryID = defaultCategory.Name;
                }
            });
        };

        initCategories();

        $scope.update = function () {
            if ($scope.form.productForm.$valid) {
                $scope.details.ProductCategoryID = _.find($scope.categories, { Name: $scope.details.ProductCategoryID }).CategoryID;
                $scope.promiseProductUpdate = ProductService.updateProduct($scope.details).then(function (result) {
                    if (result.data == "OK") {
                        $uibModalInstance.close(result.data);
                    }
                });
            } else {
                console.log('userform is not in scope');
            }
        };

        $scope.closeUpdate = function () {
            $uibModalInstance.close();
        };
    })
    .controller('ModalDeleteProductController', function ($scope, $uibModalInstance, details, ProductService) {        
        $scope.details = details;        

        $scope.deleteProduct = function () {
            ProductService.deleteProduct($scope.details.ProductID).then(function (result) {
                if (result.data == "OK") {
                    $uibModalInstance.close(result.data);
                }                
            });
        };  

        $scope.closeDetails = function () {
            $uibModalInstance.close();
        };
    });
