app.config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('associate', {
            template: '<associate></associate>',
            url: '/associate'
        })

        .state('home', {
            template: '<home></home>',
            url: '/home'
        })

        .state('login', {
            template: '<login></login>',
            url: '/login'
        })

        .state('register', {
            template: '<register></register>',
            url: '/register'
        })

        .state('welcome', {
            template: '<welcome></welcome>',
            url: '/welcome',
        });

    $urlRouterProvider.otherwise("/home");
});