
import angular = require("angular");
import 'ztree';
import 'jquery';
class ZtreeDirective implements ng.IDirective {
    restrict = "EA";
    replace = true;
    require = ['setting', 'nodes'];
    scope =
    <any>{
        "setting": "=setting",
        "nodes": "=nodes"
    };
    controller = ($scope, $element, $attrs) => {
        let setting = angular.extend({}, $scope.setting);
        $.fn.zTree.init($element, setting, $scope.nodes);
    }
}
export = new ZtreeDirective; 