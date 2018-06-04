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
            },
            deleteProduct: function (productID) {
                var data = $http.delete('/api/product/', productID).then(function (result) {
                    return result;
                }, function (err) {
                    console.log('Error in the charge of values ' + err);
                });
                return data;
            },
            updateProduct: function (values) {
                var values = JSON.stringify({
                    productID: values.ProductID,
                    description: values.Description,
                    price: values.Price,
                    name: values.Name
                });
                var data = $http.post('/api/product/', values).then(function (result) {
                    return result;
                }, function (err) {
                    console.log('Error in the charge of values ' + err);
                });
                return data;
            }
        };
        return GetApiProducts;
}]);