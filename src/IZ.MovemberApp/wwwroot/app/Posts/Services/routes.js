(function () {
    'use strict';

    angular.module('movember')
       
        .config(function ($stateProvider, $urlRouterProvider)

        {
        // for any unmatched url, redirect to state/1
        $urlRouterProvider.otherwise("/");

        // Now set up the states
        $stateProvider
            .state('list', {
                url: "/",


          /* List > Posts */
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
         /* Login >  */
              .state('login', {
                  url: "/login",

                  views: {
                      'main':
                      {
                          templateUrl: "partials/login.html",
                          controller: "LoginController as vm",
                      },
                      'title': {
                          template: 'Login'
                      }
                  }
              })
        
           /* New > Post */
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
            /* Edit > Post */
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
            })
               /* PWinners view */
            .state('winner', {
                url: "/Winners",
                views: {
                    'main':
                    {
                        templateUrl: "partials/pwView.html",
                        controller: "MenuController as vm"
                    },
                    'title': {
                        template: 'Previous winners'
                    }
                }
            })
            /* PWinners view */
        .state('about', {
            url: "/About",
            views: {
                'main':
                {
                    templateUrl: "partials/about.html",
                    controller: "MenuController as vm"
                },
                'title': {
                    template: 'About'
                }
            }
        });
    });
   

})();