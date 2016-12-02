var app = angular.module("app", ['ui.bootstrap', 'app.grid', 'ngMessages', 'ngScrollbars', 'ui.select', 'toastr'])
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
    "$filter", "toastr", function ($filter, toastr) {
        this.columnOption = window["columnOption"];
        this.success = function (msg) {
            toastr.success(msg);
        };
        this.error = function (msg) {
            toastr.error(msg);
        };
        this.warning = function (msg) {
            toastr.warning(msg);
        };
        this.info = function (msg) {
            toastr.info(msg);
        };
    }
]);
//# sourceMappingURL=app.js.map