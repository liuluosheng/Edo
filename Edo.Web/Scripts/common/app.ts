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

    }])
