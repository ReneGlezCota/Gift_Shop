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
        }

        return {
            addProduct: addProduct,
            getProducts: getProducts,
            getProductsLength : getProductsLength
        };
});