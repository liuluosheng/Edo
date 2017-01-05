var TypeScripts;
(function (TypeScripts) {
    var Template;
    (function (Template) {
        // $Classes/Enums/Interfaces(filter)[template][separator]
        // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
        // template: The template to repeat for each matched item
        // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]
        // More info: http://frhagn.github.io/Typewriter/
        var OrderDetailsViewModel = (function () {
            function OrderDetailsViewModel() {
                // ORDERID
                this.orderID = 0;
                // PRODUCTID
                this.productID = 0;
                // UNITPRICE
                this.unitPrice = 0;
                // QUANTITY
                this.quantity = 0;
                // DISCOUNT
                this.discount = 0;
                // DETAILID
                this.detailID = 0;
            }
            return OrderDetailsViewModel;
        }());
        Template.OrderDetailsViewModel = OrderDetailsViewModel;
    })(Template = TypeScripts.Template || (TypeScripts.Template = {}));
})(TypeScripts || (TypeScripts = {}));
//# sourceMappingURL=OrderDetailsViewModel.js.map