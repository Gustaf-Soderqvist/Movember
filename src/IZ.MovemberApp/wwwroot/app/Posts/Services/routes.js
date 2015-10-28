(function () {
    'use strict';

    angular.module('movember').config(function ($stateProvider, $urlRouterProvider) {
        // for any unmatched url, redirect to state/1
        $urlRouterProvider.otherwise("/");

        // Now set up the states
        $stateProvider
            .state('list', {
                url: "/",

                views: {
                    'main':
                    {
                        templateUrl: "partials/list.html",
                        controller: "ListPostController as vm",
                        resolve: {
                            postlist: function (posts) {
                                return posts.list();
                            }
                        }
                    },
                    'title': {
                        template: 'Posts'
                    }
                }
            })
            .state('new', {
                url: "/new",
                views: {
                    'main':
                    {
                        templateUrl: "partials/new.html",
                        controller: "NewPostController as vm"
                    },
                    'title': {
                        template: 'New post'
                    }
                }
            })
            .state('edit', {
                url: "/edit/:id",
                views: {
                    'main':
                    {
                        templateUrl: "partials/edit.html",
                        controller: "EditPostController as vm"
                    },
                    'title': {
                        template: 'Edit post'
                    }
                }
            });
    });
})();