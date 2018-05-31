'use strict';
angular
    .module('myApp')
    .controller('GlobalController', ['$scope', '$uibModal', '$log', function ($scope, $uibModal, $log) {

        $scope.items = ['item1', 'item2', 'item3'];

        $scope.animationsEnabled = true;

        $scope.showLogin = function () {
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                template: 'myloginModal.html',
                windowTemplateUrl: 'App/Views/Account/login.html',
                controller: 'ModalInstanceCtrl',
                controllerAs: '$scope',
                size: 'sm',
                resolve: {
                    items: function () {
                        return $scope.items;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });
        };

       

        $scope.toggleAnimation = function () {
            $scope.animationsEnabled = !$scope.animationsEnabled;
        };

        $scope.$watch('query', function (newvalue, oldvalue) {
            console.log(newvalue + ' - ' + oldvalue);
        });
    }])
    .controller('ModalInstanceCtrl', function ($uibModalInstance, items, $scope) {
        
       
        $scope.ok = function () {
            $uibModalInstance.close('load');
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
        
    });