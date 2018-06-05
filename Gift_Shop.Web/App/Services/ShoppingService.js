'use strict';

angular
    .module('myApp')
    .service('ShoppingService', function () {
        var productList = [];

        var addProduct = function (newObj) {
            productList.push(newObj);
        };

        var getProducts = function () {
            return productList;
        };

        var getProductsLength = function () {
            if (productList.length != 0) {
                return productList.length;
            }
            else {
                return 0;
            }
        };

        var deleteProduct = function (values) {
            for (var i = productList.length - 1; i >= 0; i--) {
                if (productList[i].ProductID == values) {
                    productList.splice(i, 1);
                }
            }
        };

        var deleteAll = function () {
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