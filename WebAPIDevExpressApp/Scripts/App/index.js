var myApp = angular.module('myApp', ['dx']);
myApp.controller("gridCtrl", function ($scope,$http) {

    var dataSource = new DevExpress.data.DataSource({
        store: {
            type: "odata",
            url: "http://localhost:55487/api/elemimunkas"
        }
    });
    $scope.elemiMunkakList= dataSource;

});