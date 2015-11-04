(function () {
    'use strict';

    angular.module('movember')
   .controller('LoginController',
       ['$state', 'AuthenticationService','$scope',
       function ($state, AuthenticationService, $scope) {

           var vm = this;

           vm.username = AuthenticationService.UserInfo();

           vm.login = function () {
               vm.error = undefined;
               vm.dataLoading = true;

               AuthenticationService.Login(vm.username).then(function (response) {
                   $scope.$emit("onLogin", {
                       username: vm.username
                   })

                   $state.go("list");

               },function (response) {
                   vm.error = response.data;
                   vm.dataLoading = false;
               });
           };         

           activate();

           function activate() { }
       }]);
})();