var TypeScripts;
(function (TypeScripts) {
    var Template;
    (function (Template) {
        // $Classes/Enums/Interfaces(filter)[template][separator]
        // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
        // template: The template to repeat for each matched item
        // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]
        // More info: http://frhagn.github.io/Typewriter/
        var OrderViewModel = (function () {
            function OrderViewModel() {
                // ORDERID
                this.orderID = 0;
                // SHIPNAME
                this.shipName = null;
                // SHIPADDRESS
                this.shipAddress = null;
                // SHIPCITY
                this.shipCity = null;
                // ORDERDATE
                this.orderDate = null;
                // CUSTOMERSCOMPANYNAME
                this.customersCompanyName = null;
                // CUSTOMERSCOMPANYADDRESS
                this.customersCompanyAddress = null;
                // ORDER_DETAILS
                this.order_Details = [];
            }
            return OrderViewModel;
        }());
        Template.OrderViewModel = OrderViewModel;
    })(Template = TypeScripts.Template || (TypeScripts.Template = {}));
})(TypeScripts || (TypeScripts = {}));
//# sourceMappingURL=OrderViewModel.js.map