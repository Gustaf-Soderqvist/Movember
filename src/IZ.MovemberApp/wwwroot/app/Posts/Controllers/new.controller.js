(function () {
    'use strict';

    angular
        .module('movember')
        .controller('NewPostController', newPost);

    newPost.$inject = ['posts', '$state'];

    function newPost(posts, $state) {

        var vm = this;
        vm.post = {};

        vm.post.Name = '';
        vm.post.Description = '';
        vm.post.Image = null;

        vm.save = save;

        function save(post) {
            posts.save(post).then(function() {
                $state.go("list");
            });
        }

        activate();

        function activate() { }
    }
})();
