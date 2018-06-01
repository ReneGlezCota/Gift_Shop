'use strict';

angular
    .module('myApp')
    .controller('HomeController', ['$scope', '$window', '$filter', '$uibModal', 'ProductService', 'CategoryService', 'ShoppingService', function ($scope, $window, $filter, $uibModal, ProductService, CategoryService, ShoppingService) {
        $scope.category = '';
        $scope.categories = '';
        $scope.products = '';
        $scope.filteredItems = null;        
        $scope.shoped = ShoppingService.getProductsLength();
        $scope.numPage = [{ name: 'option1', value: 3 }, { name: 'option2', value: 5 }, { name: 'option3', value: 10 }];
        $scope.numperpage = 10;

        //Function to get all products
        var initProduct = function () {
            $scope.promiseProduct = ProductService.getAllProducts().then(function (result) {
                $scope.products = result.data;
                $scope.filteredItems = result.data;
                
                initializePagination(result.data);                
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
        
        var initializePagination = function (values) {
            $scope.currentPage = 1;
            $scope.itemsPerPage = $scope.numperpage;
            $scope.maxSize = 10;
            $scope.totalItems = $scope.products.length;
        }

        $scope.setItemsPerPage = function (num) {
            $scope.numperpage = num;
            initializePagination($scope.products);
        };

        $scope.addItemToCart = function (values) {
            $scope.shoped++;
            var objProduct = {
                Name: values.Name,
                Price: values.Price,
                ProductID: values.ProductID
            };

            ShoppingService.addProduct(objProduct);            
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
