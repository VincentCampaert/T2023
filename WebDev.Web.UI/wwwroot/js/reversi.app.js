angular.module('reversiApp', ['ngRoute']).controller('reversiController', function ($scope, reversiService, $routeParams) {
    var vm = this;

    vm.gameData = null;
    vm.gameLoaded = false;
    vm.playMove = playMove;

    activate();

    function activate() {
        if (!vm.gameLoaded) {
            initGame();
        }
    };

    function initGame() {
        var gameId = $routeParams.id;

        reversiService.getGameData(gameId).then(function (response) {
            vm.gameData = response;
            vm.gameLoaded = true;
        });
    }

    function playMove(tileId) {
        var model = {
            player: vm.gameData.currentPlayer,
            tileId: tileId
        };

        reversiService.postPlayMove(model).then(function (response) {
            if (response) {
                // HTML veranderen bord, andere speler is aan beurt
            } else {
                // Illegale zet
            }
        }).catch(function (error) {
            // Backend error
        });
    }

}).factory('reversiService', function ($http) {
    var baseUrl = "/Game/";

    return {
        getGameData: function (id) {
            return $http.get(baseUrl + 'GetGameDetails', id);
        },

        postPlayMove: function (model) {
            return $http.post(baseUrl + 'PostPlayMove', model);
        }
    }
});