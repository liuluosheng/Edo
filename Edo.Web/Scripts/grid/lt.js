var Q;
(function (Q) {
    var LT = (function () {
        function LT() {
        }
        LT.prototype.initText = function (itData) {
            this.itData = itData;
        };
        LT.getText = function (path) {
            try {
                return eval(path);
            }
            catch (e) {
                return path;
            }
            ;
        };
        return LT;
    }());
    Q.LT = LT;
    function Text(path) {
        return LT.getText(path);
    }
    Q.Text = Text;
})(Q || (Q = {}));
//# sourceMappingURL=lt.js.map