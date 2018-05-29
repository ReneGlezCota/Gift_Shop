'use strict';

angular
    .module('myApp')
    .controller('HomeController', ['$scope', '$window', '$filter', 'ProductService', function ($scope, $window, $filter, ProductService) {

    $scope.hola = 'das';
    $scope.products = '';
   
}]);
