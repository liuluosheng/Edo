/// <reference path="calculator.ts" />
/// <reference path="a.ts" />
/// <reference path="../typings/angularjs/angular.d.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
define(["require", "exports"], function (require, exports) {
    "use strict";
    var Animal = (function () {
        function Animal(theName) {
            this.name = theName;
        }
        Animal.prototype.move = function (distanceInmeters) {
            if (distanceInmeters === void 0) { distanceInmeters = 0; }
            console.log(this.name + " moved " + distanceInmeters + "m.");
        };
        return Animal;
    }());
    exports.Animal = Animal;
    var Snake = (function (_super) {
        __extends(Snake, _super);
        function Snake(name) {
            _super.call(this, name);
            this.name = "";
        }
        Snake.prototype.move = function (distanceInmeters) {
            if (distanceInmeters === void 0) { distanceInmeters = 10; }
            _super.prototype.move.call(this, distanceInmeters);
        };
        return Snake;
    }(Animal));
    var Dack = (function (_super) {
        __extends(Dack, _super);
        function Dack(name) {
            _super.call(this, name);
            this.name = name;
        } //参数属性
        Object.defineProperty(Dack.prototype, "fullName", {
            get: function () {
                return this.name;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Dack.prototype, "fullname", {
            set: function (n) {
                if (n !== this.name) {
                    this.names = n;
                }
            },
            enumerable: true,
            configurable: true
        });
        return Dack;
    }(Animal));
    var Point = (function () {
        function Point() {
        }
        return Point;
    }());
    var point3d = { x: 1, y: 2, z: 3 };
    var p = { x: 5, y: 6 };
    var func = function (x, y) { return (x * y); };
    var myAdd = function (x, y) { return (x + y); };
    function option() {
        var objs = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            objs[_i - 0] = arguments[_i];
        }
        return objs.join(',');
    }
    option("a", "b");
    var Handler = (function () {
        function Handler() {
            var _this = this;
            this.onClickGood = function (e) { _this.info = ""; };
        }
        return Handler;
    }());
    function opp(x) {
        if (typeof x == "number") {
            return 1;
        }
        if (typeof x == "string") {
            return "";
        }
        return null;
    }
    //泛型
    function oppt(t) {
        return t;
    }
    ;
    var opps = (function () {
        function opps() {
        }
        return opps;
    }());
    ///联合类型
    function getValue(value) {
        return value.toString();
    }
    function getSet(param) {
        return param;
    }
    var setting = getSet("left");
    var app = angular.module("Test", []);
    app.controller("SomeController", [
        "$scope", function ($scope) {
            "use strict";
        }
    ]);
    var index = (function () {
        function index(v) {
            if (v === void 0) { v = "hello"; }
            this.v = v;
        }
        ;
        index.prototype.getv = function (param, value) {
            return false;
        };
        return index;
    }());
    var elem;
    function getCounter() {
        var counter = function (start) { };
        counter.interval = 123;
        counter.reset = function () { };
        return counter;
    }
    ;
    var v = getCounter();
    //let cqq = <Counter>(start: string) => { };
    var counter = function reset(start) { };
    counter.interval = 1;
    var Validation;
    (function (Validation) {
        var lettersRegexp = /^[A-Za-z]+$/;
        var numberRegexp = /^[0-9]+$/;
        var LettersOnlyValidator = (function () {
            function LettersOnlyValidator() {
            }
            LettersOnlyValidator.prototype.isAcceptable = function (s) {
                return lettersRegexp.test(s);
            };
            return LettersOnlyValidator;
        }());
        Validation.LettersOnlyValidator = LettersOnlyValidator;
        var ZipCodeValidator = (function () {
            function ZipCodeValidator() {
            }
            ZipCodeValidator.prototype.isAcceptable = function (s) {
                return s.length === 5 && numberRegexp.test(s);
            };
            return ZipCodeValidator;
        }());
        Validation.ZipCodeValidator = ZipCodeValidator;
    })(Validation || (Validation = {}));
});
//# sourceMappingURL=d.js.map