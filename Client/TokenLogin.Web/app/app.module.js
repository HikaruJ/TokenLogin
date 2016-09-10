
var app = angular.module('TokenLoginApp', ['ui.router', 'LocalStorageModule', 'angular-loading-bar']);

//var serviceBase = 'http://localhost:26264/';
var serviceBase = 'http://localhost:58251/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


