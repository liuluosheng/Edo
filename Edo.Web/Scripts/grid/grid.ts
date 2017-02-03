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
class GridController {
    static $inject = ["$scope", "$sce", "$filter", "$http", "$uibModal", "$attrs", "$common", "$parse"];
    //declare 
    page: any;
    gridOption: any;
    data: any[];
    lastPageFilter;
    filterObj = {};
    psArray: number[];
    gridSort = {};
    dataLoading: boolean = true;
    columnfields;
    paging;
    getconspan: () => number;
    sort: (a) => void;
    rowSelected: (a: any) => void;
    renderRowDetail: (a: any) => string;
    getFilterString: () => string;
    filter: (a: string | boolean) => void;
    filterNum: (a: string, b: string) => void;
    clearFilter: (a: string) => void;
    getSelectFilter: (a: string) => any;
    formatter;
    delete;
    scrolls;
    dialog;
    isArray;
    create;
    createObj;
    //
    constructor(
        $scope,
        $sce,
        $filter,
        $http,
        $uibModal,
        $attrs,
        $common,
        $parse) {
        this.gridOption = angular.extend(
            {
                height: 'auto',
                rowNumber: false,
                rowDetail: true,
                filterRow: false,
                showBtn: {
                    edit: true,
                    del: true
                },
                onRowSelected(row) { }
                // ,onRenderRowDetail: function (row) { }
            }, {
                pkColumn: $attrs.gridPkColumn || $scope.option.pkColumn || "Id", //必须项
                itemFilterField: $attrs.gridItemField || null,
                moreToMore: $attrs.gridMoreToMore === "true" || false, // 多对多关系
                columns: $common.gridOptions[$scope.gridName]["columns"],
                propbtns: $common.gridOptions[$scope.gridName]["btns"],
                url: $attrs.gridUrl || $scope.option.url, //必须项
                selectUrl: $attrs.gridSelectUrl || $scope.option.selectUrl, //必须项
                deleteUrl: $attrs.gridDeleteUrl,
                editTemplateUrl: $attrs.gridEditTemplateUrl || $scope.option.editTemplateUrl,//必须项
                isDetail: $attrs.gridDetail || false,
                showBtn: {
                    edit: $attrs.gridEnableEdit != "false",
                    del: $attrs.gridEnableDelete != "false"
                }
            }, $scope.option);
        this.page = {
            pageIndex: 1,
            pageSize: 10,
            sort: `${this.gridOption.itemFilterField || this.gridOption.pkColumn} descending`
        }
        this.columnfields = $.map(this.gridOption.columns, (v) => {
            return v.id;
        });
        this.paging = (p, isfilter = false) => {
            if (isfilter && this.lastPageFilter != null && this.lastPageFilter == p.filter) return;
            if (this.gridOption.moreToMore && this.gridOption.itemFilter) p.itemFilter = this.gridOption.itemFilter; // 多对多时
            $http.post(this.gridOption.url, p).success(result => {
                this.lastPageFilter = p.filter;
                p.total = result.total;
                this.data = result.data;
                //$scope.bindModel($scope.data);
                this.dataLoading = false;
                if (!isfilter && $scope.option.filterRow)
                    this.gridOption.filterRow = p.pageSize >= p.total ? false : true;
            }).error(result => {
                this.dataLoading = false;
                $common.$alert.error($T.DataLoadError);
            });
        }
        this.getconspan = (): number => { return this.gridOption.columns.length + (this.gridOption.rowDetail || this.gridOption.showBtn ? 1 : 0) + (this.gridOption.rowNumber ? 1 : 0) };
        this.sort = (op) => {
            if (!op.sortable) return;
            let sortBy = this.gridSort["field"] !== op.field ? "ascending" : this.gridSort["sort"] === "descending" ? "ascending" : "descending";
            let sort = `${op.field} ${sortBy}`;
            this.gridSort = { field: op.field, sort: sortBy };
            this.page.sort = sort;
            this.paging(this.page);
        }
        this.rowSelected = (row) => {
            if (row.$selected) return;
            this.gridOption.selectedRow = row;
            $scope.option.selectedRow = row;
            angular.forEach(this.data, (v) => { delete v.$selected });
            row.$selected = true;
            if (angular.isFunction(this.gridOption.onRowSelected))
                this.gridOption.onRowSelected(row);
        }
        this.renderRowDetail = (row): string => {
            if (angular.isFunction(this.gridOption.onRenderRowDetail))
                return $sce.trustAsHtml(this.gridOption.onRenderRowDetail(row));
        }
        this.getFilterString = (): string => {
            let values = [];
            angular.forEach(this.filterObj, (v, k) => {
                let col = $filter('filter')(this.gridOption.columns, { field: k });
                if (col.length !== 0) {
                    if (v != null || v !== "") {
                        switch (col[0].type) {
                            case "Text":
                                values.push(`${k}.ToString().Contains(\"${v}\")`);
                                break;
                            case "Number":
                                values.push(v.value);
                                break;
                            case "Date":
                                {
                                    let s = [];
                                    if (angular.isDate(v.start)) {
                                        s.push(`${k} >= \"${$filter('date')(v.start, 'yyyy-MM-dd')}\"`);
                                    }
                                    if (angular.isDate(v.end)) {
                                        s.push(`${k} <= \"${$filter('date')(v.end, 'yyyy-MM-dd')}\"`);
                                    }
                                    if (s.length !== 0)
                                        values.push(s.join(' and '));
                                }

                        }
                    }
                }
            });
            if (this.gridOption.itemFilter && !this.gridOption.moreToMore) {
                values.push(this.gridOption.itemFilter);
            }
            return values.join(' and ');
        }
        this.filter = (filterIsOpen) => {
            if (filterIsOpen) return;
            this.page["filter"] = this.getFilterString();
            this.page.pageIndex = 1;
            this.paging(this.page, true);
        }
        this.clearFilter = (field) => {
            delete this.filterObj[field];
            this.filter(false);
        }
        this.filterNum = (field, option) => {
            if (this.filterObj[field].text == "") {
                this.clearFilter(field);
                return;
            }
            if (this.filterObj[field] && !isNaN(<any>this.filterObj[field].text)) {
                this.filterObj[field].value = `${field} ${option} ${this.filterObj[field].text}`;
                this.filter(false);
            }
        }
        this.getSelectFilter = (field) => {
            let str = this.getFilterString();
            let param = { field: field, q: str };
            if (this.gridOption.moreToMore && this.page["itemFilter"]) param["itemFilter"] = this.page["itemFilter"];
            return $http.post(this.gridOption.selectUrl, param).then(result => result.data.items);
        }
        this.formatter = (formatter, value, row) => { eval(`(${formatter})`)(value, row) };
        this.delete = (item, $index) => {
            $common.$alert.confirm($T.ConfirmDelete, { title: "" }).then((isConfirm) => {
                if (isConfirm) {
                    let api = this.gridOption.moreToMore ? this.gridOption.deleteUrl : `${$scope.gridName}/delete`;
                    let param = this.gridOption.moreToMore ? { id: this.gridOption.itemFilterValue, itemId: item.Id } : item;
                    $http.post(api, param).success((result) => {
                        if (result.Success) {
                            setTimeout(() => { $common.$alert.success($T.AlertSuccess); }, 200);
                            this.paging(this.page);
                        } else
                            setTimeout(() => { $common.$alert.error(result.Message || $T.AlertError); }, 200);
                    });
                }
            });
        }
        this.scrolls =
            {
                config: {
                    autoHideScrollbar: false,
                    theme: 'dark-3',
                    scrollInertia: 0,
                    axis: 'x',
                    mouseWheel: { enable: false }
                }
            }
        this.dialog = (resolveObj, resultFn, template) => {
            let modalInstance = $uibModal.open({
                windowTemplateUrl: "/ngTemplate/modal-template.html",
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: template,
                controller: 'editCtrl',
                controllerAs: "vm",
                backdrop: "static",
                resolve: {
                    resolveObj() {
                        return resolveObj;
                    }
                }
            }).result.then(resultFn);
        }
        this.isArray = (value) => {
            return angular.isArray(value);
        }
        this.create = (item) => {
            let isNew = item == null;
            item = item || {};
            var resolve = {
                item: item,
                gridOption: {
                    itemFilterValue: item[this.gridOption.pkColumn]
                }
            };
            if (this.gridOption.itemFilterField)
                resolve["fkName"] = this.gridOption.itemFilterField;
            this.dialog(resolve, (result) => {
                if (result.Success) {
                    $common.$alert.success($T.AlertSuccess);
                    if (isNew)
                        this.paging(this.page);
                    else
                        item = angular.extend(item, result.editObj, result.Obj)

                } else
                    $common.$alert.error(result.Message || $T.AlertError);
            }, this.gridOption.editTemplateUrl)
        }
        this.createObj = (template, fkName, fkValue) => {
            let resolve = {
                fkName: fkName,
                item: {},
                gridOption: {
                    showBtn: false,
                    filterRow: true
                }
            };
            if (fkName)
                resolve.item[fkName] = fkValue;
            this.dialog(resolve, (result) => {
                let message = (data) => {
                    if (data.Success) {
                        $common.$alert.success($T.AlertSuccess);
                    } else
                        $common.$alert.error(data.Message || $T.AlertError);
                }
                if (result.api) {
                    let param = { id: this.gridOption.selectedRow.Id, itemId: result.selected.Id };
                    $http.post(`${$scope.gridName}/create${result.api}`, param).success((data) => {
                        message(data);
                    });
                } else
                    message(result);
            }, template)
        };
        //$scope.gridOption.filterRow = false;
        this.psArray = this.gridOption.isDetail ? [10] : [10, 20, 50, 100];
        if (this.gridOption.itemFilterField) {
            this.gridOption.itemFilter = `${this.gridOption.itemFilterField} = "${this.gridOption.itemFilterValue || $common.emptyGuid}"`;
        }
        $scope.option.create = this.create;
        this.page["filter"] = this.getFilterString();
        this.paging(this.page);
    }
}
class EditGridController {
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

function FilterColumn(item, arrays) {
    let obj = {};
    angular.forEach(item, (value, key) => {
        if ($.inArray(key, <any>arrays) === -1 && key.indexOf("$$") !== 0)
            obj[key] = value;
    });
    return obj;
}

angular.module("app.grid", ['ngSanitize'])
    .directive("grid", () => new GridDirective())
    .controller("gridController", GridController)
    .controller("editCtrl", EditGridController)
    .filter("filterColumn", () => FilterColumn);


