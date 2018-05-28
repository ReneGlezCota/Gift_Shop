'use strict';

var myApp = angular.module('myApp', []);

myApp.service('ProductService', ['$http', '$q', function ($http, $q) {
    var result;
    var GetApiProducts = {
        getAllProducts: function () {
            var data = $http.get('/api/product/').then(function (result) {
                return result;
            }, function (err) {
                console.log('Error in the charge of values ' + err);
            });
            return data;
        }
    };
    return GetApiProducts;
}]);