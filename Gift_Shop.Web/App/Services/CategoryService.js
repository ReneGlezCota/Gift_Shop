'use strict';

angular
    .module('myApp')
    .service('CategoryService', ['$http', function ($http) {
        var result;
        var GetApiCategories = {
            getAllCategories: function () {
                var data = $http.get('/api/category/').then(function (result) {
                    return result;
                }, function (err) {
                    console.log('Error in the charge of values ' + err);
                });
                return data;
            }
        };
        return GetApiCategories;
    }]);