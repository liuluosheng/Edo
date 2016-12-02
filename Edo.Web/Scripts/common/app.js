var app = angular.module("app", ['ui.bootstrap', 'app.grid', 'ngMessages', 'ngScrollbars', 'ui.select'])
    .service("appService", [
        "$filter", "$window", function ($filter, $window) {
            $window.formatterDate = function (value) {
                return $filter("date")(value, "yyyy-MM-dd");
            }
        }
    ]);
