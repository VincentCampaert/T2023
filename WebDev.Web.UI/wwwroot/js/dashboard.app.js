angular.module('dashboardApp', ['ngRoute']).controller('dashboardController', function ($scope, dashboardService) {
    var vm = this;

    activate();

    function activate() {
        

        dashboardService.getPlayerData().then(function (response) {

        });
    };

}).factory('dashboardService', function ($http) {
    return {
        getPlayerData: function (id) {
            return $http({
                method: 'GET',
                url: 'getPlayerData/' + id,
                headers: {
                    'Content-Type': 'application/json'
                }
            });
        },
    }
});