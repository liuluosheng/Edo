/// <reference path="icustom.ts" />
import angular = require("angular");
import ztreeDerective = require("zTreeDirective");
let app = angular.module("app");
app.directive("ztree", () => ztreeDerective);
class UserPermissions implements ICoustom {
    $inject = ["$scope"];
    constructor($scope) {
        $scope.test = "111";
        $scope.nodes = [
            { id: 1, pId: 0, name: "普通的父节点", t: "我很普通，随便点我吧", open: true },
            { id: 11, pId: 1, name: "叶子节点 - 1", t: "我很普通，随便点我吧" },
            { id: 12, pId: 1, name: "叶子节点 - 2", t: "我很普通，随便点我吧" }
        ];
        $scope.setting = {};
    }
}
export = UserPermissions;