class GridDirective implements ng.IDirective {
    restrict = "EA";
    templateUrl = "/ngTemplate/ngGrid.html";
    replace = true;
    controller = "gridController";
    controllerAs = "ctrl";
    scope =
    <any>{
        "option": "=gridOption",
        "gridName": "@gridName"
    };
}
export = GridDirective;