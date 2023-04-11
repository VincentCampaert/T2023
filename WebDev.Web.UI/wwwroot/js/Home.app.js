angular.module('homeApp', ['ngRoute']).controller('homeController', function ($scope, homeService) {
    var vm = this;

    vm.gameData = null;
    vm.gameLoaded = false;
    vm.playMove = playMove;

    activate();

    function activate() {
        console.log("TEST");
    };

}).factory('homeService', function ($http) {
    return {
        postLogin: function (email, password) {
            return $http({
                method: 'POST',
                url: 'OnPostLogin',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: {
                    email: email,
                    password: password
                }
            });
        }
    }
});