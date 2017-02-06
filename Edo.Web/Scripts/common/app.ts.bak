/// <reference path="../typings/sweetalert/sweetalert.d.ts" />
///<reference path="../common/GridOptions.ts"/>

"use strict";
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
angular.module("app", ['ui.bootstrap', 'ui.bootstrap.datetimepicker', 'app.grid', 'ngMessages', 'ngScrollbars', 'toastr', 'ng-sweet-alert'])
    .controller("appController", appController)
    .service("$common", commonService)
    .config(toastrConfig);

