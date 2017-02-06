class EditController {
    static $inject = ["$scope", "$http", "$uibModalInstance", "$uibModal", "$common", "$window"];
    //declare 
    modalHeight: number;
    item: any;
    fkName: string;
    gridOption: any;
    choose: (a) => void;
    chooseObj: (a, b, c, d, e) => void;
    ok: (a, b) => void;
    scrollTo: (a) => void;
    scrolls: any;
    cancel: () => void;
    //
    constructor($scope, $http, $uibModalInstance, $uibModal, $common, $window) {
        this.modalHeight = angular.element(window).height() - 230;
        this.item = angular.copy($scope.$resolve.resolveObj.item) || {};
        this.fkName = $scope.$resolve.resolveObj.fkName;
        this.gridOption = angular.extend({}, $scope.$resolve.resolveObj.gridOption);
        this.choose = (api) => {
            if (this.gridOption.selectedRow) {
                $uibModalInstance.close({
                    selected: this.gridOption.selectedRow,
                    api
                });
            } else
                $common.$toast.error($T.AlertSelect);
        }
        this.chooseObj = (template, field, name, bindName, eventObj) => {
            if ($(eventObj.target).is("[disabled]") || $(eventObj.target).parent().is("[disabled]")) return;
            $uibModal.open({
                windowTemplateUrl: "/ngTemplate/modal-template.html",
                templateUrl: template,
                controller: 'editCtrl',
                controllerAs: "vm",
                backdrop: "static",
                resolve: {
                    resolveObj() {
                        return {
                            gridOption: {
                                showBtn: false,
                                filterRow: true
                            }
                        };
                    }
                }
            }).result.then((result) => {
                this.item[field] = result.selected.Id;
                this.item[name] = result.selected[bindName];
            });
        }
        this.ok = (form, api) => {
            if (form.$invalid) {
                $common.$toast.error($T.FormValidateError);
                return;
            }
            let method = this.gridOption.itemFilterValue ? "edit" : "create";
            $http.post(api + method, this.item).success((result) => {
                result.editObj = this.item;
                $uibModalInstance.close(result);
            })
        };
        this.scrollTo = targetSelection => {
            let top = angular.element(targetSelection).position().top;
            this.scrolls.updateScrollbar('scrollTo', top);
        };
        this.scrolls =
            {
                config: {
                    autoHideScrollbar: false,
                    theme: 'dark-3',
                    scrollInertia: 0,
                    axis: 'y'
                }
            }
        this.cancel = () => {
            $uibModalInstance.dismiss('cancel');
        };
    }
}

export = EditController;