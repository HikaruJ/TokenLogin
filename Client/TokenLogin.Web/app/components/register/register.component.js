(function () {
    "use strict";

    var registerComponent = {
        bindings: {},
        controller: RegisterController,
        templateUrl: 'app/components/register/register.view.html'
    };

    function RegisterController ($scope, $location, $timeout, authService) {
        var ctrl = this;

        ctrl.savedSuccessfully = false;
        ctrl.message = "";

        ctrl.registration = {
            userName: "",
            password: "",
            confirmPassword: ""
        };

        ctrl.register = function () {
            authService.saveRegistration(ctrl.registration).then(function (response) {
                ctrl.savedSuccessfully = true;
                ctrl.message = "User has been registered successfully, you will be redirected to login page in 2 seconds.";
                startTimer();

            }, function (response) {
                var errors = [];
                for (var key in response.data.modelState) {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
                ctrl.message = "Failed to register user due to:" + errors.join(' ');
            });
        };

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $location.path('/login');
            }, 2000);
        }
    };

    app.component('register', registerComponent);
}());