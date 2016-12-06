/// <reference path="../typings/sweetalert/sweetalert.d.ts" />
var app = angular.module("app", ['ui.bootstrap', 'app.grid', 'ngMessages', 'ngScrollbars', 'ui.select', 'toastr', 'ng-sweet-alert'])
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
        this.columnOption = window["columnOption"];
        //提示框服务
        this.$toast = $toast;
        this.$alert = $sweetAlert;
    }
]);
//# sourceMappingURL=app.js.map