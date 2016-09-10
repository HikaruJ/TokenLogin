(function () {
    "use strict";

    var headerComponent = {
        bindings: {},
        controller: HeaderController,
        templateUrl: 'app/components/shared/header/header.view.html'
    };

    function HeaderController($scope, $location, authService) {
        var ctrl = this;

        ctrl.logOut = function () {
            authService.logOut();
            $location.path('/home');
        }

        ctrl.authentication = authService.authentication;
    };

    app.component('header', headerComponent);
}());