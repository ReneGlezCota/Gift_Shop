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
                var data = $http.delete('/api/product/' + productID).then(function (result) {
                    return result;
                }, function (err) {
                    console.log('Error in the delete the values ' + err);
                });
                return data;
            },
            updateProduct: function (values) {
                var productData = {
                    ProductID: values.ProductID,
                    ProductDescription: values.ProductDescription,
                    ProductPrice: values.ProductPrice,
                    ProductName: values.ProductName,
                    ProductCategory: values.ProductCategoryID,
                    ProductFile: 'default.jpg'
                };
                var data = $http.put('/api/product/', productData).then(function (result) {
                    return result;
                }, function (err) {
                    console.log('Error in the update the values ' + err);
                });
                return data;
            },
            addProduct: function (values) {
                var productData = {
                    ProductDescription: values.ProductDescription,
                    ProductPrice: values.ProductPrice,
                    ProductName: values.ProductName,
                    ProductCategory: values.ProductCategoryID,
                    ProductFile: 'default.jpg'
                };
                var data = $http.post('/api/product/', productData).then(function (result) {
                    return result;
                }, function (err) {
                    console.log('Error in the add the values ' + err);
                });
                return data;
            }
        };
        return GetApiProducts;
}]);