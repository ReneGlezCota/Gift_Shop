'use strict';

angular
    .module('myApp')
    .service('AuthenticateService', ['$http', function ($http) {
        var result;
        var GetApiAuthenticate = {
            getLoginUser: function (username, password) {
                var values = JSON.stringify({ username : username, password : password});
                var data = $http.post('/api/user/', values).then(function (result) {
                    return result;
                }, function (err) {
                    console.log('Error in the charge of values ' + err);
                });
                return data;
            }
        };
        return GetApiAuthenticate;
    }]);