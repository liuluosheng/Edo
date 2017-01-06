var GridDirective = (function () {
    function GridDirective() {
        this.restrict = "EA";
        this.templateUrl = "/ngTemplate/ngGrid.html";
        this.replace = true;
        this.controller = "gridController";
        this.controllerAs = "ctrl";
        this.scope = {
            "option": "=gridOption",
            "gridName": "@gridName"
        };
    }
    return GridDirective;
}());
var GridController = (function () {
    //
    function GridController($scope, $sce, $filter, $http, $uibModal, $attrs, $common, $parse) {
        var _this = this;
        this.filterObj = {};
        this.gridSort = {};
        this.dataLoading = true;
        this.gridOption = angular.extend({
            height: 'auto',
            rowNumber: false,
            rowDetail: true,
            filterRow: false,
            showBtn: {
                edit: true,
                del: true
            },
            onRowSelected: function (row) { }
        }, {
            pkColumn: $attrs.gridPkColumn || $scope.option.pkColumn || "Id",
            itemFilterField: $attrs.gridItemField || null,
            moreToMore: $attrs.gridMoreToMore === "true" || false,
            columns: $common.gridOptions[$scope.gridName]["columns"],
            propbtns: $common.gridOptions[$scope.gridName]["btns"],
            url: $attrs.gridUrl || $scope.option.url,
            selectUrl: $attrs.gridSelectUrl || $scope.option.selectUrl,
            deleteUrl: $attrs.gridDeleteUrl,
            editTemplateUrl: $attrs.gridEditTemplateUrl || $scope.option.editTemplateUrl,
            isDetail: $attrs.gridDetail || false,
            showBtn: {
                edit: $attrs.gridEnableEdit != "false",
                del: $attrs.gridEnableDelete != "false"
            }
        }, $scope.option);
        this.page = {
            pageIndex: 1,
            pageSize: 10,
            sort: (this.gridOption.itemFilterField || this.gridOption.pkColumn) + " descending"
        };
        this.columnfields = $.map(this.gridOption.columns, function (v) {
            return v.id;
        });
        this.paging = function (p, isfilter) {
            if (isfilter === void 0) { isfilter = false; }
            if (isfilter && _this.lastPageFilter != null && _this.lastPageFilter == p.filter)
                return;
            if (_this.gridOption.moreToMore && _this.gridOption.itemFilter)
                p.itemFilter = _this.gridOption.itemFilter; // 多对多时
            $http.post(_this.gridOption.url, p).success(function (result) {
                _this.lastPageFilter = p.filter;
                p.total = result.total;
                _this.data = result.data;
                //$scope.bindModel($scope.data);
                _this.dataLoading = false;
                if (!isfilter)
                    _this.gridOption.filterRow = p.pageSize >= p.total ? false : $scope.option.filterRow;
            }).error(function (result) {
                _this.dataLoading = false;
                $common.$alert.error($T.DataLoadError);
            });
        };
        this.getconspan = function () { return _this.gridOption.columns.length + (_this.gridOption.rowDetail || _this.gridOption.showBtn ? 1 : 0) + (_this.gridOption.rowNumber ? 1 : 0); };
        this.sort = function (op) {
            if (!op.sortable)
                return;
            var sortBy = _this.gridSort["field"] !== op.field ? "ascending" : _this.gridSort["sort"] === "descending" ? "ascending" : "descending";
            var sort = op.field + " " + sortBy;
            _this.gridSort = { field: op.field, sort: sortBy };
            _this.page.sort = sort;
            _this.paging(_this.page);
        };
        this.rowSelected = function (row) {
            if (row.$selected)
                return;
            _this.gridOption.selectedRow = row;
            $scope.option.selectedRow = row;
            angular.forEach(_this.data, function (v) { delete v.$selected; });
            row.$selected = true;
            if (angular.isFunction(_this.gridOption.onRowSelected))
                _this.gridOption.onRowSelected(row);
        };
        this.renderRowDetail = function (row) {
            if (angular.isFunction(_this.gridOption.onRenderRowDetail))
                return $sce.trustAsHtml(_this.gridOption.onRenderRowDetail(row));
        };
        this.getFilterString = function () {
            var values = [];
            angular.forEach(_this.filterObj, function (v, k) {
                var col = $filter('filter')(_this.gridOption.columns, { field: k });
                if (col.length !== 0) {
                    if (v != null || v !== "") {
                        switch (col[0].type) {
                            case "Text":
                                values.push(k + ".ToString().Contains(\"" + v + "\")");
                                break;
                            case "Number":
                                values.push(v.value);
                                break;
                            case "Date":
                                {
                                    var s = [];
                                    if (angular.isDate(v.start)) {
                                        s.push(k + " >= \"" + $filter('date')(v.start, 'yyyy-MM-dd') + "\"");
                                    }
                                    if (angular.isDate(v.end)) {
                                        s.push(k + " <= \"" + $filter('date')(v.end, 'yyyy-MM-dd') + "\"");
                                    }
                                    if (s.length !== 0)
                                        values.push(s.join(' and '));
                                }
                        }
                    }
                }
            });
            if (_this.gridOption.itemFilter && !_this.gridOption.moreToMore) {
                values.push(_this.gridOption.itemFilter);
            }
            return values.join(' and ');
        };
        this.filter = function (filterIsOpen) {
            if (filterIsOpen)
                return;
            _this.page["filter"] = _this.getFilterString();
            _this.page.pageIndex = 1;
            _this.paging(_this.page, true);
        };
        this.clearFilter = function (field) {
            delete _this.filterObj[field];
            _this.filter(false);
        };
        this.filterNum = function (field, option) {
            if (_this.filterObj[field].text == "") {
                _this.clearFilter(field);
                return;
            }
            if (_this.filterObj[field] && !isNaN(_this.filterObj[field].text)) {
                _this.filterObj[field].value = field + " " + option + " " + _this.filterObj[field].text;
                _this.filter(false);
            }
        };
        this.getSelectFilter = function (field) {
            var str = _this.getFilterString();
            var param = { field: field, q: str };
            if (_this.gridOption.moreToMore && _this.page["itemFilter"])
                param["itemFilter"] = _this.page["itemFilter"];
            return $http.post(_this.gridOption.selectUrl, param).then(function (result) { return result.data.items; });
        };
        this.formatter = function (formatter, value, row) { eval("(" + formatter + ")")(value, row); };
        this.delete = function (item, $index) {
            $common.$alert.confirm($T.ConfirmDelete, { title: "" }).then(function (isConfirm) {
                if (isConfirm) {
                    var api = _this.gridOption.moreToMore ? _this.gridOption.deleteUrl : $scope.gridName + "/delete";
                    var param = _this.gridOption.moreToMore ? { id: _this.gridOption.itemFilterValue, itemId: item.Id } : item;
                    $http.post(api, param).success(function (result) {
                        if (result.Success) {
                            setTimeout(function () { $common.$alert.success($T.AlertSuccess); }, 200);
                            _this.paging(_this.page);
                        }
                        else
                            setTimeout(function () { $common.$alert.error(result.Message || $T.AlertError); }, 200);
                    });
                }
            });
        };
        this.scrolls =
            {
                config: {
                    autoHideScrollbar: false,
                    theme: 'dark-3',
                    scrollInertia: 0,
                    axis: 'x',
                    mouseWheel: { enable: false }
                }
            };
        this.dialog = function (resolveObj, resultFn, template) {
            var modalInstance = $uibModal.open({
                windowTemplateUrl: "/ngTemplate/modal-template.html",
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: template,
                controller: 'editInstanceCtrl',
                controllerAs: "vm",
                backdrop: "static",
                resolve: {
                    resolveObj: function () {
                        return resolveObj;
                    }
                }
            }).result.then(resultFn);
        };
        this.isArray = function (value) {
            return angular.isArray(value);
        };
        this.create = function (item) {
            var isNew = item == null;
            item = item || {};
            var resolve = {
                item: item,
                gridOption: {
                    itemFilterValue: item[_this.gridOption.pkColumn]
                }
            };
            if (_this.gridOption.itemFilterField)
                resolve["fkName"] = _this.gridOption.itemFilterField;
            _this.dialog(resolve, function (result) {
                if (result.Success) {
                    $common.$alert.success($T.AlertSuccess);
                    if (isNew)
                        _this.paging(_this.page);
                    else
                        item = angular.extend(item, result.editObj, result.Obj);
                }
                else
                    $common.$alert.error(result.Message || $T.AlertError);
            }, _this.gridOption.editTemplateUrl);
        };
        this.createObj = function (template, fkName, fkValue) {
            var resolve = {
                fkName: fkName,
                item: {},
                gridOption: {
                    showBtn: false,
                    filterRow: true
                }
            };
            if (fkName)
                resolve.item[fkName] = fkValue;
            _this.dialog(resolve, function (result) {
                var message = function (data) {
                    if (data.Success) {
                        $common.$alert.success($T.AlertSuccess);
                    }
                    else
                        $common.$alert.error(data.Message || $T.AlertError);
                };
                if (result.api) {
                    var param = { id: _this.gridOption.selectedRow.Id, itemId: result.selected.Id };
                    $http.post($scope.gridName + "/create" + result.api, param).success(function (data) {
                        message(data);
                    });
                }
                else
                    message(result);
            }, template);
        };
        //$scope.gridOption.filterRow = false;
        this.psArray = this.gridOption.isDetail ? [10] : [10, 20, 50, 100];
        if (this.gridOption.itemFilterField) {
            this.gridOption.itemFilter = this.gridOption.itemFilterField + " = \"" + (this.gridOption.itemFilterValue || $common.emptyGuid) + "\"";
        }
        $scope.option.create = this.create;
        this.page["filter"] = this.getFilterString();
        this.paging(this.page);
    }
    GridController.$inject = ["$scope", "$sce", "$filter", "$http", "$uibModal", "$attrs", "$common", "$parse"];
    return GridController;
}());
var EditGridController = (function () {
    //
    function EditGridController($scope, $http, $uibModalInstance, $uibModal, $common, $window) {
        var _this = this;
        this.modalHeight = angular.element(window).height() - 230;
        this.item = angular.copy($scope.$resolve.resolveObj.item) || {};
        this.fkName = $scope.$resolve.resolveObj.fkName;
        this.gridOption = angular.extend({}, $scope.$resolve.resolveObj.gridOption);
        this.choose = function (api) {
            if (_this.gridOption.selectedRow) {
                $uibModalInstance.close({
                    selected: _this.gridOption.selectedRow,
                    api: api
                });
            }
            else
                $common.$toast.error($T.AlertSelect);
        };
        this.chooseObj = function (template, field, name, bindName) {
            $uibModal.open({
                windowTemplateUrl: "/ngTemplate/modal-template.html",
                templateUrl: template,
                controller: 'editInstanceCtrl',
                controllerAs: "vm",
                backdrop: "static",
                resolve: {
                    resolveObj: function () {
                        return {
                            gridOption: {
                                showBtn: false,
                                filterRow: true
                            }
                        };
                    }
                }
            }).result.then(function (result) {
                _this.item[field] = result.selected.Id;
                _this.item[name] = result.selected[bindName];
            });
        };
        this.ok = function (form, api) {
            if (form.$invalid) {
                $common.$toast.error($T.FormValidateError);
                return;
            }
            var method = _this.gridOption.itemFilterValue ? "edit" : "create";
            $http.post(api + method, _this.item).success(function (result) {
                result.editObj = _this.item;
                $uibModalInstance.close(result);
            });
        };
        this.scrollTo = function (targetSelection) {
            var top = angular.element(targetSelection).position().top;
            _this.scrolls.updateScrollbar('scrollTo', top);
        };
        this.scrolls =
            {
                config: {
                    autoHideScrollbar: false,
                    theme: 'dark-3',
                    scrollInertia: 0,
                    axis: 'y'
                }
            };
        this.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
    EditGridController.$inject = ["$scope", "$http", "$uibModalInstance", "$uibModal", "$common", "$window"];
    return EditGridController;
}());
function FilterColumn(item, arrays) {
    var obj = {};
    angular.forEach(item, function (value, key) {
        if ($.inArray(key, arrays) === -1 && key.indexOf("$$") !== 0)
            obj[key] = value;
    });
    return obj;
}
angular.module("app.grid", ['ngSanitize'])
    .directive("grid", function () { return new GridDirective(); })
    .controller("gridController", GridController)
    .controller("editInstanceCtrl", EditGridController)
    .filter("filterColumn", function () { return FilterColumn; });
//# sourceMappingURL=grid.js.map