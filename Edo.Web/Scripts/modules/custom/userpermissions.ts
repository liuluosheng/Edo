/// <reference path="icustom.ts" />
import angular = require("angular");
import ztreeDerective = require("zTreeDirective");
let app = angular.module("app");
app.directive("ztree", () => ztreeDerective);
class UserPermissions implements ICoustom {
    $inject = ["$scope"];
    constructor($scope) {
        $scope.test = "111";
        $scope.nodes = edo.TreePermissionKeys.value;
        $scope.setting = {check: {enable:true} };
    }
}
export = UserPermissions;