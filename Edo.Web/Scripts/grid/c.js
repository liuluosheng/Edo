define(["require", "exports"], function (require, exports) {
    "use strict";
    var Good = (function () {
        function Good() {
        }
        Good.sayGood = function (name) {
            alert("Hello," + name + ",You are Good!");
            console.log(name + ".");
        };
        return Good;
    }());
    var Bad = (function () {
        function Bad() {
        }
        Bad.sayBad = function (name) {
            alert("Hello," + name + ",You are Bad!");
            console.log(name + ".");
        };
        return Bad;
    }());
    return {
        Good: Good, Bad: Bad
    };
});
//# sourceMappingURL=c.js.map