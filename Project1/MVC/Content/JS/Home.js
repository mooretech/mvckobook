namespace('MVCKO.Project1.Home');

MVCKO.Project1.Home.app = function() {

    function HomeViewModel(teams) {
        var self = this;

        self.teams = ko.observableArray(teams);
    }

    function initialize(teams) {
        var viewModel = new HomeViewModel(teams);

        ko.applyBindings(viewModel);
    }

    return {
        initialize: initialize
    };
}();

$(function () { MVCKO.Project1.Home.app.initialize(__teams); });