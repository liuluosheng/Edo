/// <reference path="../typings/sweetalert/sweetalert.d.ts" />
var app = angular.module("app", ['ui.bootstrap', 'ui.bootstrap.datetimepicker', 'app.grid', 'ngMessages', 'ngScrollbars', 'toastr', 'ng-sweet-alert'])
    .config(function (toastrConfig) {
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
    }).service("$common", [
        "$filter", "toastr", "SweetAlert", function ($filter, $toast, $sweetAlert) {
            this.gridOptions = window["gridOptions"];
            //提示框服务
            this.$toast = $toast;
            this.$alert = $sweetAlert;
            this.emptyGuid = "00000000-0000-0000-0000-000000000000";
        }
    ])
    .controller("appController", ["$scope", ($scope) => {
        $scope.sysMenu = [
            { name: "Orders", url: "/orders", icon: "fa-html5" },
            { name: "Region", url: "/region", icon: "fa-cc-mastercard" },
            { name: "Products", url: "/products", icon: "fa-pie-chart" },
            { name: "系统管理", children: [{ name: "User", url: "/user", icon: "fa-user" }, { name: "Role", url: "/role", icon: "fa-users" }], icon: "fa-cog" }
        ];
    }])
