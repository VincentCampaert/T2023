angular.module('reversiApp', ['ngRoute']).controller('reversiController', function ($scope, reversiService) {
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
        var gameId = location.pathname.split('/')[3];

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
    var baseUrl = location.pathname.split('/')[3] + "/";

    return {
        getGameData: function (id) {
            return $http({
                method: 'GET',
                url: 'GetGameDetails/' + id,
                headers: {
                    'Content-Type': 'application/json'
                }
            });
        },

        postPlayMove: function (model) {
            return $http.post(baseUrl + 'PostPlayMove', model);
        }
    }
});