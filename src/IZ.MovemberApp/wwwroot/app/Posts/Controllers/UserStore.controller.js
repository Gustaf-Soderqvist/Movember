(function () {
    'use strict';

    angular
        .module('movember')
        .controller('UserStoreController', function($scope, $window, $cookieStore) {
            $scope.WriteCookie = function() {
                $cookieStore.put("Email", $scope.Email);
            };
            $scope.ReadCookike = function() {
                $window.alert($cookieStore.get('Email'));
            };
        });


})();