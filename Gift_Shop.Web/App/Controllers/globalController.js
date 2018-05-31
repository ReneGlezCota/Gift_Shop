'use strict';
angular
    .module('myApp')
    .controller('GlobalController', ['$scope', '$uibModal', '$log', function ($scope, $uibModal, $log) {       
        $scope.valuesLogin = '';
        $scope.showLogin = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'App/Views/Templates/login.html',
                controller: 'ModalInstanceCtrl',
                size : 'lg'
            });

            modalInstance.result.then(function (values) {
                $scope.valuesLogin = values;



            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });

            console.log($scope.valuesLogin);
        };

        $scope.$watch('query', function (newvalue, oldvalue) {
            console.log(newvalue + ' - ' + oldvalue);
        });
    }])
    .controller('ModalInstanceCtrl', function ($scope, $uibModalInstance) {
        $scope.login = function (values) {
            //console.log(values);
            $uibModalInstance.close(values);
        };

        $scope.closeLogin = function () {
            $uibModalInstance.dismiss('cancel');
        };
        
    });