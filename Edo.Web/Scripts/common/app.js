/// <reference path="../typings/sweetalert/sweetalert.d.ts" />
///<reference path="../common/GridOptions.ts"/>
"use strict";
var appController = (function () {
    function appController($scope) {
        $scope.sysMenu = [
            { name: "Orders", url: "/orders", icon: "fa-html5" },
            { name: "Region", url: "/region", icon: "fa-cc-mastercard" },
            { name: "Products", url: "/products", icon: "fa-pie-chart" },
            { name: "系统管理", children: [{ name: "User", url: "/user", icon: "fa-user" }, { name: "Role", url: "/role", icon: "fa-users" }], icon: "fa-cog" }
        ];
    }
    appController.$inject = ["$scope"];
    return appController;
}());
var commonService = (function () {
    function commonService($filter, $toast, $sweetAlert) {
        this.$toast = $toast;
        this.$alert = $sweetAlert;
        this.emptyGuid = "00000000-0000-0000-0000-000000000000";
        this.gridOptions = edo.GridOption.value;
    }
    commonService.$inject = ["$filter", "toastr", "SweetAlert"];
    return commonService;
}());
var toastrConfig = (function () {
    function toastrConfig(toastrConfig) {
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
    return toastrConfig;
}());
angular.module("app", ['ui.bootstrap', 'ui.bootstrap.datetimepicker', 'app.grid', 'ngMessages', 'ngScrollbars', 'toastr', 'ng-sweet-alert'])
    .controller("appController", appController)
    .service("$common", commonService)
    .config(toastrConfig);
//# sourceMappingURL=app.js.map