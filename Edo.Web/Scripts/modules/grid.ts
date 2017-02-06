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
require(["angular-sanitize"], function () {
    angular.module("app.grid", ['ngSanitize'])
        .directive("grid", () => gridDirective)
        .controller("gridController", gridController)
        .controller("editCtrl", editController)
        .filter("filterColumn", () => FilterColumn);
})
