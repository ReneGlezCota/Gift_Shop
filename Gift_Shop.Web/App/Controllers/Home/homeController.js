'use strict';

angular
    .module('myApp')
    .controller('HomeController', ['$scope', '$window', '$filter', '$uibModal', 'ProductService', 'CategoryService', function ($scope, $window, $filter, $uibModal, ProductService, CategoryService) {
        $scope.category = '';
        $scope.categories = '';
        $scope.products = '';
        $scope.filteredItems = null;
   
        var initProduct = function () {
            $scope.promiseProduct = ProductService.getAllProducts().then(function (result) {
                $scope.products = result.data;
                $scope.filteredItems = result.data;
                console.log(result.data);
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
                    $scope.category = 'All';
                }
            });
        };

        initProduct();
        initCategories();

        $scope.filterByCategory = function (value) {
            var category = _.find($scope.categories, { "Name": value });
            $scope.products = $scope.filteredItems;
            if (value != 'All') {
                var obj = _($scope.products).filter(function (r) {
                    if (_(r['CategoryID']).toString().toUpperCase().includes(category.CategoryID.toString().toUpperCase())) { return true; };
                    return false;
                  }
                ).value();

                $scope.products = obj;
            }
        };

        $scope.showCarShop = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Templates/carshop.html',
                controller: 'ModalShopCartController'
            });

            //modalInstance.result.then(function (values) {           
            //}, function () {
            //    $log.info('Modal dismissed at: ' + new Date());
            //});
        };

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
                name: values.name,
                price: values.price
            });
        };



    }])
    .controller('ModalShopCartController', function ($scope, $uibModalInstance) {
        $scope.close = function () {
            $uibModalInstance.dismiss('cancel');
        };
    });
