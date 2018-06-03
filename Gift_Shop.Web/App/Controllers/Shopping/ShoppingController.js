'use strict';

angular
    .module('myApp')
    .controller('ShoppingController', ['$scope', '$window', '$filter', '$uibModal', '$state', 'ShoppingService', function ($scope, $window, $filter, $uibModal, $state, ShoppingService) {
        
        $scope.products = ShoppingService.getProducts();
        $scope.count = 1;
        $scope.total = 0;

        $scope.returnPage = function () {
            $state.go('home')
        };

        $scope.showPay = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Modals/payment.html',
                controller: 'ModalPaymentController'
            });
        }

        $scope.deleteItem = function (values) {
            ShoppingService.deleteProduct(values);
        };







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

       
    }])
    .controller('ModalPaymentController', function ($scope, $rootScope, $uibModalInstance, $cookies) {

        $scope.closePayment = function () {
            $uibModalInstance.close();
        };
    });
