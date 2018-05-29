'use strict';
angular
    .module('myApp')
    .controller('GlobalController', ['$scope', '$window', '$filter', function ($scope, $window, $filter) {
        $scope.$watch('query', function (newvalue, oldvalue) {
            console.log(newvalue + ' - ' + oldvalue);
        });
}]);