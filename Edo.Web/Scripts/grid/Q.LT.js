var Q;
(function (Q) {
    var LT = (function () {
        function LT() {
        }
        LT.getText = function (key) {
            return this.itData[key];
        };
        return LT;
    }());
    Q.LT = LT;
    function Text(key) {
        return LT.getText(key);
    }
    Q.Text = Text;
})(Q || (Q = {}));
Q.LT.itData = ["a", ""];
//# sourceMappingURL=Q.LT.js.map