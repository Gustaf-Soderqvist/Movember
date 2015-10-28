(function () {
    'use strict';

    angular
        .module('movember')
        .controller('ListPostController', listPosts);

    listPosts.$inject = ['postlist', '$state'];

    function listPosts(postlist, $state) {
        /* jshint validthis:true */
        var vm = this;
        vm.posts = postlist;

        vm.goto = goto;
        vm.new = newPost;

        function goto(post) {
            $state.go('edit', { id: post.id });

        };

        function newPost() {
            $state.go('new');
        }
    }
})();
