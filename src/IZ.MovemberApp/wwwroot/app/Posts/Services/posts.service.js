(function () {
    'use strict';

    angular
        .module('movember')
        .factory('posts', posts);

    posts.$inject = ['$http', '$log'];

    function posts($http, $log) {
        $log.info("Post called");
 
        var service = {
            save: save,
            load: get,
            list: list,
            remove: remove
        };

        function save(post) {
            return $http.post('/api/post', post).then(function (res,status,headers,config)
            {
                return res.data;
            });
        }

        function remove(id) {
            return $http.delete('/api/post/' + id).then(function(res, status, headers, config) {
                return res.data;
            });
        }

        function get(id) {
                return $http.get('/api/post' + id).then(function(res, status, headers, config) {
                    return res.data;
                });
            }

        function list() {
                    return $http.get('/api/post').then(function(res, status, headers, config) {
                        return res.data;
                    });
            }

        return service;
    };
})();