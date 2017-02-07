/// <reference path="../typings/sweetalert/sweetalert.d.ts" />
///<reference path="../common/GridOptions.ts"/>
import angular = require("angular");
import gridController = require("gridController");
import gridDirective = require("gridDirective");
import editController = require("editController");
function FilterColumn(item, arrays) {
    let obj = {};
    angular.forEach(item, (value, key) => {
        if ($.inArray(key, <any>arrays) === -1 && key.indexOf("$$") !== 0)
            obj[key] = value;
    });
    return obj;
}
class appController {
    static $inject = ["$scope"];
    constructor($scope) {
        $scope.sysMenu = [
            { name: "Orders", url: "/orders", icon: "fa-html5" },
            { name: "Region", url: "/region", icon: "fa-cc-mastercard" },
            { name: "Products", url: "/products", icon: "fa-pie-chart" },
            { name: "系统管理", children: [{ name: "User", url: "/user", icon: "fa-user" }, { name: "Role", url: "/role", icon: "fa-users" }], icon: "fa-cog" }
        ];
    }
}
class commonService {
    static $inject = ["$filter", "toastr", "SweetAlert"];
    $toast;
    $alert;
    emptyGuid;
    gridOptions;
    constructor($filter, $toast, $sweetAlert) {
        this.$toast = $toast;
        this.$alert = $sweetAlert;
        this.emptyGuid = "00000000-0000-0000-0000-000000000000";
        this.gridOptions = edo.GridOption.value;
    }
}
class toastrConfig {
    constructor(toastrConfig) {
        angular.extend(toastrConfig, {
            autoDismiss: false,
            containerId: 'toast-container',
            maxOpened: 0,
            newestOnTop: true,
            positionClass: 'toast-top-right',
            preventDuplicates: false,
            preventOpenDuplicates: true,
            progressBar: true,
            target: 'body'
        });
    }
}
angular.module("app", ['ui.bootstrap', 'ui.bootstrap.datetimepicker', 'ngMessages', 'ngScrollbars', 'toastr', 'ng-sweet-alert', 'ngSanitize'])
    .controller("appController", appController)
    .directive("grid", () => gridDirective)
    .controller("gridController", gridController)
    .controller("editCtrl", editController)
    .filter("filterColumn", () => FilterColumn)
    .service("$common", commonService)
    .config(toastrConfig);
require([
    "angularui-bootstrap",
    "angular-datetimepicker-templates",
    "angular-sanitize",
    "angular-messages",
    "angular-scrollbars",
    "angular-toast",
    "angular-sweetalert"
], function () {
    angular.bootstrap(document, ['app']);
});