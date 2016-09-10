(function () {
    "use strict";

    var footerComponent = {
        bindings: {},
        controller: FooterController,
        templateUrl: 'app/components/shared/footer/footer.view.html'
    };

    function FooterController($state) {

    };

    app.component('footer', footerComponent);
}());