'use strict';

angular
    .module('myApp')
    .service('ShoppingService', function ($cookies) {
        var productList = [];

        var addProduct = function (newObj) {
            productList.push(newObj);
            $cookies.putObject('myProducts', productList);            
        };

        var getProducts = function () {
            var productList = $cookies.getObject('myProducts');
            return productList;
        };

        var getProductsLength = function () {            
            productList = $cookies.getObject('myProducts');            
            if (productList && productList.length != 0) {
                return productList.length;
            }
            else {
                productList = [];
                return 0;
            }
        };

        var deleteProduct = function (values) {
            productList = $cookies.getObject('myProducts');
            for (var i = productList.length - 1; i >= 0; i--) {
                if (productList[i].ProductID == values) {
                    productList.splice(i, 1);
                    $cookies.putObject('myProducts', productList);
                    return productList;
                }
            }
        };

        var deleteAll = function () {
            $cookies.remove('myProducts');
            productList = [];
        };

        return {
            addProduct: addProduct,
            getProducts: getProducts,
            getProductsLength: getProductsLength,
            deleteProduct: deleteProduct,
            deleteAll: deleteAll
        };
});