/// <reference path="icustom.ts" />
import angular = require("angular");
class UserPermissions implements ICoustom {
    $inject = ["$scope"];
    constructor($scope) {
        let app = angular.module("app");
        $scope.test = 123322;
    }
}
export = UserPermissions;