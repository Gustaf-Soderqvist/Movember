(function () {
    'use strict';

    angular
        .module('movember')
        .controller('EditPostController', editPost);

    editPost.$inject = ['posts', '$stateParams', '$state'];

    function editPost(posts, $stateParams, $state) {

        var vm = this;
        vm.post = {};

        vm.post.Id = '';
        vm.post.Name = '';
        vm.post.Description = '';
        vm.post.Image = null;

        vm.save = save;
        vm.remove = remove;

        function save(post) {
            posts.save(post).then(function() {
                $state.go("list");
            });
        }

        function remove(post) {
            posts.remove(post.Id).then(function() {
                $state.go("list");
            });
        }

        activate();

        function activate() {
            var id = $stateParams.id;
            posts.load(id).then(function(post) {
                vm.post = post;
            });
        }
    }
})();