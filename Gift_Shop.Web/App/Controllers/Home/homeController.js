'use strict';

angular
    .module('myApp')
    .controller('HomeController', ['$scope', '$window', '$filter', '$uibModal', 'ProductService', 'CategoryService', function ($scope, $window, $filter, $uibModal, ProductService, CategoryService) {
        $scope.category = '';
        $scope.categories = '';
        $scope.products = '';
        $scope.filteredItems = null;
        $scope.shoped = [];
        
        //Function to get all products
        var initProduct = function () {
            $scope.promiseProduct = ProductService.getAllProducts().then(function (result) {
                $scope.products = result.data;
                $scope.filteredItems = result.data;

                $scope.currentPage = 1;
                $scope.itemsPerPage = 2;
                $scope.maxSize = 10;
                $scope.totalItems = $scope.products.length; 
            });
        };

        //Function to get all categories
        var initCategories = function () {
            $scope.promiseCategory = CategoryService.getAllCategories().then(function (result) {
                $scope.categories = result.data;
                if ($scope.categories != null) {
                    $scope.categories.push({
                        CategoryID: 0,
                        Name: 'All',
                        Products : null
                    })
                    $scope.category = 'All';
                }
            });
        };

        //Charge the all values
        initProduct();
        initCategories();
       
        //Show de CarShop modal
        $scope.showCarShop = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Modals/carshop.html',
                controller: 'ModalShopCartController'
            });

            //modalInstance.result.then(function (values) {           
            //}, function () {
            //    $log.info('Modal dismissed at: ' + new Date());
            //});
        };
        
        //Filter by Category
        $scope.filterByCategory = function (value) {
            var category = _.find($scope.categories, { "Name": value });
            $scope.products = $scope.filteredItems;
            if (value != 'All') {
                var obj = _($scope.products).filter(function (r) {
                    if (_(r['CategoryID']).toString().toUpperCase().includes(category.CategoryID.toString().toUpperCase())) { return true; };
                    return false;
                }).value();

                $scope.products = obj;
            }
        };

        //Filter by Product Name
        $scope.$watch('query', function (newvalue, oldvalue) {
            $scope.products = $scope.filteredItems;
            var obj = _($scope.products).filter(
              function (r) {
                  if (_(r['Name']).toString().toUpperCase().includes(newvalue.toString().toUpperCase())) { return true; };
                  return false;
              }
            ).value();

            $scope.products = obj;
        });


        $scope.addItemToCart = function (values) {
            $scope.shoped.push({
                Name: values.Name,
                Price: values.Price,
                ProductID: values.ProductID
            });

            console.log($scope.shoped);
        };


        
              

    }])
    .filter('offset', function () {
        return function (input, start) {
            return input.slice(start);
        };
    })
    .controller('ModalShopCartController', function ($scope, $uibModalInstance) {
        $scope.close = function () {
            $uibModalInstance.dismiss('cancel');
        };
    });
