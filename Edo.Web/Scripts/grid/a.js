define(["require", "exports", "./c"], function (require, exports, Good) {
    "use strict";
    //import Good from "./c";
    var Hello = (function () {
        function Hello() {
        }
        Hello.sayHello = function (name) {
            // alert(`Hello,${name}`);
            console.log(name + ".");
            Good.Good.sayGood(name);
            Good.Bad.sayBad(name);
        };
        return Hello;
    }());
    return Hello;
});
//let hello: Hello = new Hello();
//hello.sayHello("Li");
//import Good from "./c";
//Good.sayGood("He");
//# sourceMappingURL=a.js.map