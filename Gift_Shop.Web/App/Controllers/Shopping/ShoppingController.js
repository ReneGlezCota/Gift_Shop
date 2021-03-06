﻿'use strict';

angular
    .module('myApp')
    .controller('ShoppingController', ['$scope', '$window', '$filter', '$uibModal', '$state', 'ShoppingService', '$rootScope', '$cookies', function ($scope, $window, $filter, $uibModal, $state, ShoppingService, $rootScope, $cookies) {
        
        $scope.products = ShoppingService.getProducts();
        $scope.count = 1;
        $scope.total = 0;

        $scope.returnPage = function () {
            $state.go('home');
        };

        $scope.showPay = function (items) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Modals/payment.html',
                controller: 'ModalPaymentController',
                resolve: {
                    elements: function () {
                        return items;
                    }
                }
            });

            modalInstance.result.then(function (value) {
                if (value) {
                    $scope.products = ShoppingService.deleteAll()
                    $scope.returnPage();
                }                
            });
        }

        $scope.deleteItem = function (values) {
            ShoppingService.deleteProduct(values);
            $scope.products = ShoppingService.getProducts();

            $scope.getTotal();
        };

        $scope.getTotal = function () {
            var total = 0;
            if ($scope.products) {
                for (var i = 0; i < $scope.products.length; i++) {
                    var element = $scope.products[i];
                    total += element.Price
                }
            }
            
            return total;
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
                $uibModalInstance.close(true);                                   
            } else {
                console.log('userform is not in scope');
            }
        };

        $scope.closePayment = function () {
            $uibModalInstance.close();
        };
    });
