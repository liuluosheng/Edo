var TypeScripts;
(function (TypeScripts) {
    var Template;
    (function (Template) {
        // $Classes/Enums/Interfaces(filter)[template][separator]
        // filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
        // template: The template to repeat for each matched item
        // separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]
        // More info: http://frhagn.github.io/Typewriter/
        var UserModel = (function () {
            function UserModel() {
                // NAME
                this.name = null;
            }
            return UserModel;
        }());
        Template.UserModel = UserModel;
    })(Template = TypeScripts.Template || (TypeScripts.Template = {}));
})(TypeScripts || (TypeScripts = {}));
//# sourceMappingURL=UserModel.js.map