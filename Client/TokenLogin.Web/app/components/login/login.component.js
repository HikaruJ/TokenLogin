(function () {
    "use strict";

    var loginComponent = {
        bindings: {},
        controller: LoginController,
        templateUrl: 'app/components/login/login.view.html'
    };

    function LoginController ($scope, $location, authService, ngAuthSettings) {
        var ctrl = this;

        ctrl.loginData = {
            userName: "",
            password: "",
            useRefreshTokens: false
        };

        ctrl.message = "";

        ctrl.login = function () {
            authService.login(ctrl.loginData).then(function (response) {
                $location.path('/welcome');
            }, function (err) {
                 ctrl.message = err.error_description;
            });
        };

        ctrl.authExternalProvider = function (provider) {
            var redirectUri = location.protocol + '//' + location.host + '/authcomplete.html';
            var externalProviderUrl = ngAuthSettings.apiServiceBaseUri + "api/Account/ExternalLogin?provider=" + provider
                                                                        + "&response_type=token&client_id=" + ngAuthSettings.clientId
                                                                        + "&redirect_uri=" + redirectUri;
            window.$windowScope = ctrl;

            var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
        };

        ctrl.authCompletedCB = function (fragment) {
            ctrl.$apply(function () {
                if (fragment.haslocalaccount == 'False') {
                    authService.logOut();

                    authService.externalAuthData = {
                        provider: fragment.provider,
                        userName: fragment.external_user_name,
                        externalAccessToken: fragment.external_access_token
                    };

                    $location.path('/associate');
                } else {
                    //Obtain access token and redirect to orders
                    var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };
                    authService.obtainAccessToken(externalData).then(function (response) {
                        $location.path('/welcome');
                    }, function (err) {
                     ctrl.message = err.error_description;
                 });
                }
            });
        }
    };

    app.component('login', loginComponent);
}());