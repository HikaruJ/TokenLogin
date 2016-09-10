(function () {
    "use strict";

    var welcomeComponent = {
        bindings: {},
        controller: WelcomeController,
        templateUrl: 'app/components/welcome/welcome.view.html'
    };

    function WelcomeController($scope) {

    };

    app.component('welcome', welcomeComponent);
}());