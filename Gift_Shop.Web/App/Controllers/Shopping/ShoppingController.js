'use strict';

angular
    .module('myApp')
    .controller('ShoppingController', ['$scope', '$window', '$filter', '$uibModal', '$state', 'ShoppingService', '$rootScope', '$cookies', function ($scope, $window, $filter, $uibModal, $state, ShoppingService, $rootScope, $cookies) {
        
        $scope.products = ShoppingService.getProducts();
        $scope.count = 1;
        $scope.total = 0;

        $scope.returnPage = function () {
            $state.go('home');
        };

        $scope.showPay = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Modals/payment.html',
                controller: 'ModalPaymentController'
            });

            modalInstance.result.then(function () {
                $scope.products = ShoppingService.deleteAll()
                $scope.returnPage();
            });
        }

        $scope.deleteItem = function (values) {
            ShoppingService.deleteProduct(values);
            $scope.products = ShoppingService.getProducts();
        };

        $scope.totalPaye = function (price, count) {
            var value = $scope.total - price;

            $scope.total = value + (price * count);
        }; 

        var init = function () {
            $scope.uservalues = '';
            $rootScope.globals = $cookies.getObject('globals') || {};
            if ($rootScope.globals.currentUser) {
                $scope.uservalues = $rootScope.globals.currentUser;
            }
        };

        init();
       
    }])
    .controller('ModalPaymentController', function ($scope, $rootScope, $uibModalInstance, $cookies) {

        $scope.pay = function () {
            if ($scope.form.pay.$valid) {
                $uibModalInstance.close();                                   
            } else {
                console.log('userform is not in scope');
            }
        };

        $scope.closePayment = function () {
            $uibModalInstance.close();
        };
    });
