'use strict';
angular
    .module('myApp')
    .controller('GlobalController', ['$scope', '$uibModal', '$log', '$rootScope', '$cookies', '$state', function ($scope, $uibModal, $log, $rootScope, $cookies, $state) {
        $scope.login = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Modals/login.html',
                controller: 'ModalLoginController'
            });

            modalInstance.result.then(function (values) {
                $rootScope.globals = {
                    currentUser: {
                        username: values.UserName,
                        firstname: values.FirstName,
                        lastname: values.LastName,
                        roleid: values.RoleID
                    }
                };

                var cookieExp = new Date();
                cookieExp.setDate(cookieExp.getDate() + 1);
                $cookies.putObject('globals', $rootScope.globals, { expires: cookieExp });
                init();

                window.location.reload();

            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });            
        };

        $scope.logout = function () {
            $rootScope.globals = {};
            $cookies.remove('globals');
            init();
        };
        
        var init = function () {
            $scope.uservalues = '';
            $rootScope.globals = $cookies.getObject('globals') || {};
            if ($rootScope.globals.currentUser) {
                $scope.uservalues = $rootScope.globals.currentUser;
            }
        };

        init();

        $scope.productPage = function () {
            $state.go('product');
        }

    }])
    .controller('ModalLoginController', function ($scope, $rootScope, $uibModalInstance, AuthenticateService, $cookies) {
        $scope.form = {}
        $scope.promiseLogin = '';
        $scope.login = function () {
            if ($scope.form.userForm.$valid) {

                $scope.promiseLogin = AuthenticateService.getLoginUser($scope.username, $scope.password).then(function (result) {
                    if (result.data) {
                        $rootScope.globals = {};
                        $cookies.remove('globals');
                        $uibModalInstance.close(result.data);

                    }
                    else {
                        $scope.message = 'Username or Password is incorrect.'
                    }
                });
            } else {
                console.log('userform is not in scope');
            }
        };

        $scope.closeLogin = function () {
            $uibModalInstance.dismiss('cancel');
        };
        
    });