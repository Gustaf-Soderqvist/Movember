(function () {
    'use strict';

    angular
        .module('movember')
        .controller('UserController', ctrl);

    ctrl.$inject = ['AuthenticationService', '$state', '$rootScope'];

    function ctrl(AuthenticationService, $state, $rootScope) {

        var vm = this;
   
        vm.userName = AuthenticationService.UserInfo();

        $rootScope.$on("onLogin", function (event, args) {
            vm.userName = AuthenticationService.UserInfo();
        });

        vm.directToLogin = function () {      
            $state.go("login");
        }

        vm.logout = function () {

            vm.dataLoading = true;
            AuthenticationService.Logout().then(function (response) {

                vm.userName = AuthenticationService.UserInfo();
                vm.directToLogin();

            }, function (response) {
                vm.error = response;
                vm.dataLoading = false;
            });
        };
        activate();

        function activate() { }
    }

})();