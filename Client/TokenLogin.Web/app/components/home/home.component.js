(function () {
    "use strict";

    var homeComponent = {
        bindings: {},
        controller: HomeController,
        templateUrl: 'app/components/home/home.view.html'
    };

    function HomeController($scope) {

    };

    app.component('home', homeComponent);
}());