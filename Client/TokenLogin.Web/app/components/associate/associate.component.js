(function () {
    "use strict";

    var associateComponent = {
        bindings: {},
        controller: AssociateController,
        templateUrl: 'app/components/associate/associate.view.html'
    };

    function AssociateController($scope, $location, $timeout, authService) {
        ctrl.savedSuccessfully = false;
        ctrl.message = "";

        ctrl.registerData = {
            userName: authService.externalAuthData.userName,
            provider: authService.externalAuthData.provider,
            externalAccessToken: authService.externalAuthData.externalAccessToken
        };

        ctrl.registerExternal = function () {
            authService.registerExternal(ctrl.registerData).then(function (response) {
                ctrl.savedSuccessfully = true;
                ctrl.message = "User has been registered successfully, you will be redirected to orders page in 2 seconds.";
                startTimer();

            }, function (response) {
                var errors = [];
                for (var key in response.modelState) {
                    errors.push(response.modelState[key]);
                }
                ctrl.message = "Failed to register user due to:" + errors.join(' ');
            });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/orders');
            }, 2000);
        }
    };

    app.component('associate', associateComponent);
}());