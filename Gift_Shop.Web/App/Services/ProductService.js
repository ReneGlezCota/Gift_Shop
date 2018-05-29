'use strict';

angular
    .module('myApp')
    .service('ProductService', ['$http', function ($http) {
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