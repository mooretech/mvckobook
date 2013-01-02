namespace('MVCKO.Project1.Home');

MVCKO.Project1.Home.app = function() {

    var _newPlayerID = -1;
    var _newTeamID = -1;

    function HomeViewModel(teams) {
        var self = this;

        self.modalModel = {
            editingPlayer: ko.observable({}),

            show: ko.observable(false),
            save: function() { self.modalSave(); },
            close: function() {
                // clear out the editing player
                editingPlayer({});
                
                // close the modal
                show(false);
            }
        };

        self.teams = ko.mapping.fromJS(teams);
        self.teamDetailVisible = ko.observable(false);
        self.editingTeam = ko.observable({});
   
        self.editPlayer = function (player) {
            var playerCopy = ko.mapping.fromJS(ko.mapping.toJS(player));

            self.modalModel.editingPlayer(playerCopy);
            self.modalModel.show(true);
        };

        self.cancelTeamEdit = function () {
            self.editingTeam({});
        };

        self.newTeam = function () {
            var newTeam = ko.mapping.fromJS(__newTeamTemplate);
            newTeam.Name('New Team');
            newTeam.TeamID(_newTeamID);
            _newTeamID--;

            self.teams.push(newTeam);
            self.editingTeam(self.teams()[self.teams().length - 1]);
        };

        self.newPlayer = function () {
            var newPlayer = ko.mapping.fromJS(__newPlayerTemplate);
            newPlayer.Name('New Player');
            newPlayer.PlayerID(_newPlayerID);
            _newPlayerID--;

            self.editingTeam().Players.push(newPlayer);

            self.editPlayer(newPlayer);
        };

        self.editingTeam.subscribe(function () {
            // fires when editing team is changed
            self.teamDetailVisible(self.editingTeam().TeamID!=null);
        });

        self.playerCount = function (team) {
            return team.Players().length;
        };

        self.positionName = function(id) {
            for (var x = 0; x < __positions.length; x++) {
                if (__positions[x].PositionID == id) {
                    return __positions[x].Name;
                }
            }

            return '';
        };

        self.editTeam = function (team) {
            self.editingTeam(team);
        };

        self.modalSave = function () {
            var editedPlayer = self.modalModel.editingPlayer();

            var players = self.editingTeam().Players();
            for (var x = 0; x < players.length; x++) {
                if (players[x].PlayerID() == editedPlayer.PlayerID()) {
                    self.editingTeam().Players.replace(players[x], editedPlayer);
                    break;
                }
            }

            self.modalModel.show(false);
        };
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