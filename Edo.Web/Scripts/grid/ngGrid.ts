﻿
/// <reference path="../typings/angularjs/angular.d.ts" />
/// <reference path="../typings/jquery/jquery.d.ts" />
declare var $T: any;
angular.module("app.grid", ['ngSanitize']).directive("grid", [
    "$http", ($http, attrs) => {
        return {
            restrict: 'EA',
            templateUrl: (element: any, attrs: any) => {
                if (!attrs.gridTemplate) attrs.gridTemplate = "ngGrid";
                return `/ngTemplate/${attrs.gridTemplate}.html`;
            },
            scope:
            {
                "option": "=gridOption",
                "gridName": "@gridName"
            },
            replace: true,
            controller: "GridController"
        };
    }
]).controller("GridController", [
    "$scope", "$sce", "$filter", "$http", "$uibModal", "$attrs", "$common", "$parse", ($scope, $sce, $filter, $http, $uibModal, $attrs, $common, $parse) => {
        $scope.gridOption = angular.extend(
            {
                height: 'auto',
                rowNumber: false,
                rowDetail: true,
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
        $scope.gridOption.filterRow = false;
        $scope.bindModel = (value) => {
            let modelAttr = $attrs.ngModel;
            if (modelAttr) {
                $parse(modelAttr).assign($scope.$parent, value);
            }
        }
        $scope.psArray = $scope.gridOption.isDetail ? [10] : [10, 20, 50, 100];
        $scope.page = {
            pageIndex: 1,
            pageSize: $scope.psArray[0],
            sort: `${$scope.gridOption.itemFilterField || $scope.gridOption.pkColumn} descending`
        }
        if ($scope.gridOption.itemFilterField) {
            $scope.gridOption.itemFilter = `${$scope.gridOption.itemFilterField} = "${$scope.gridOption.itemFilterValue || $common.emptyGuid}"`;
        }
        $scope.gridSort = {};
        $scope.columnfields = $.map($scope.gridOption.columns, (v) => {
            return v.id;
        });
        $scope.dataLoading = true;
        $scope.paging = (p, isfilter = false) => {
            if (isfilter && $scope.lastPageFilter != null && $scope.lastPageFilter == p.filter) return;
            if ($scope.gridOption.moreToMore && $scope.gridOption.itemFilter) p.itemFilter = $scope.gridOption.itemFilter; // 多对多时
            $http.post($scope.gridOption.url, p).success(result => {
                $scope.lastPageFilter = p.filter;
                p.total = result.total;
                $scope.data = result.data;
                //$scope.bindModel($scope.data);
                $scope.dataLoading = false;
                if (!isfilter)
                    $scope.gridOption.filterRow = p.pageSize >= p.total ? false : $scope.option.filterRow
            }).error(result => {
                $scope.dataLoading = false;
                $common.$alert.error($T.DataLoadError);
            });
        }

        $scope.getconspan = (): number => { return $scope.gridOption.columns.length + ($scope.gridOption.rowDetail || $scope.gridOption.showBtn ? 1 : 0) + ($scope.gridOption.rowNumber ? 1 : 0) };
        $scope.sort = (op) => {
            if (!op.sortable) return;
            let sortBy = $scope.gridSort.field !== op.field ? "ascending" : $scope.gridSort.sort === "descending" ? "ascending" : "descending";
            let sort = `${op.field} ${sortBy}`;
            $scope.gridSort = { field: op.field, sort: sortBy };
            $scope.page.sort = sort;
            $scope.paging($scope.page);
        }
        $scope.rowSelected = (row) => {
            if (row.$selected) return;
            $scope.gridOption.selectedRow = row;
            $scope.option.selectedRow = row;
            angular.forEach($scope.data, (v) => { delete v.$selected });
            row.$selected = true;
            if (angular.isFunction($scope.gridOption.onRowSelected))
                $scope.gridOption.onRowSelected(row);
        }
        $scope.renderRowDetail = (row): string => {
            if (angular.isFunction($scope.gridOption.onRenderRowDetail))
                return $sce.trustAsHtml($scope.gridOption.onRenderRowDetail(row));
        }
        $scope.filterObj = {};
        $scope.filter = filterIsOpen => {
            if (filterIsOpen) return;
            $scope.page.filter = $scope.getFilterString();
            $scope.page.pageIndex = 1;
            $scope.paging($scope.page, true);
        }
        $scope.clearFilter = (field) => {
            delete $scope.filterObj[field];
            $scope.filter();
        }
        $scope.filterNum = (field, option) => {
            if ($scope.filterObj[field] && !isNaN(<any>$scope.filterObj[field].text)) {
                $scope.filterObj[field].value = `${field} ${option} ${$scope.filterObj[field].text}`;
                $scope.filter();
            }
        }
        $scope.getSelectFilter = (field) => {
            let str = $scope.getFilterString();
            let param = { field: field, q: str };
            if ($scope.gridOption.moreToMore && $scope.page.itemFilter) param["itemFilter"] = $scope.page.itemFilter;
            return $http.post($scope.gridOption.selectUrl, param).then(result => result.data.items);
        }

        $scope.getFilterString = (): string => {
            let values = [];
            angular.forEach($scope.filterObj, (v, k) => {
                let col = $filter('filter')($scope.gridOption.columns, { field: k });
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
            if ($scope.gridOption.itemFilter && !$scope.gridOption.moreToMore) {
                values.push($scope.gridOption.itemFilter);
            }
            return values.join(' and ');
        }
        $scope.page.filter = $scope.getFilterString();
        $scope.paging($scope.page);
        $scope.formatter = (formatter, value, row) => eval(`(${formatter})`)(value, row);
        $scope.delete = (item, $index) => {
            $common.$alert.confirm($T.ConfirmDelete, { title: "" }).then(function (isConfirm) {
                if (isConfirm) {
                    let api = $scope.gridOption.moreToMore ? $scope.gridOption.deleteUrl : `${$scope.gridName}/delete`;
                    let param = $scope.gridOption.moreToMore ? { id: $scope.gridOption.itemFilterValue, itemId: item.Id } : item;
                    $http.post(api, param).success(function (result) {
                        if (result.Success) {
                            setTimeout(function () { $common.$alert.success($T.AlertSuccess); }, 200);
                            $scope.paging($scope.page);
                        } else
                            setTimeout(function () { $common.$alert.error(result.Message || $T.AlertError); }, 200);
                    });
                }
            });
        }
        $scope.scrolls =
            {
                config: {
                    autoHideScrollbar: false,
                    theme: 'dark-3',
                    scrollInertia: 0,
                    axis: 'x',
                    mouseWheel: { enable: false }
                }
            }
        let dialog = (resolveObj, resultFn, template) => {
            let modalInstance = $uibModal.open({
                windowTemplateUrl: "/ngTemplate/modal-template.html",
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: template,
                controller: 'editCtrl',
                backdrop: "static",
                resolve: {
                    resolveObj() {
                        return resolveObj;
                    }
                }
            }).result.then(resultFn);
        };
        $scope.isArray = (value) => {
            return angular.isArray(value);
        }
        //create: 主表更新或创建数据行
        $scope.create = item => {
            let isNew = item == null;
            item = item || {};
            var resolve = {
                item: item,
                gridOption: {
                    itemFilterValue: item[$scope.gridOption.pkColumn]
                }
            };
            if ($scope.gridOption.itemFilterField)
                resolve["fkName"] = $scope.gridOption.itemFilterField;
            dialog(resolve, function (result) {
                if (result.Success) {
                    $common.$alert.success($T.AlertSuccess);
                    if (isNew)
                        $scope.paging($scope.page);
                    else
                        item = angular.extend(item, result.editObj, result.Obj)

                } else
                    $common.$alert.error(result.Message || $T.AlertError);
            }, $scope.gridOption.editTemplateUrl)
        }
        $scope.option.create = $scope.create;
        // createObj: 创建详情行
        $scope.createObj = (template, fkName, fkValue) => {
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
            dialog(resolve, function (result) {
                let message = (data) => {
                    if (data.Success) {
                        $common.$alert.success($T.AlertSuccess);
                    } else
                        $common.$alert.error(data.Message || $T.AlertError);
                }
                if (result.api) {
                    let param = { id: $scope.gridOption.selectedRow.Id, itemId: result.selected.Id };
                    $http.post(`${$scope.gridName}/create${result.api}`, param).success(function (data) {
                        message(data);
                    });
                } else
                    message(result);
            }, template)
        };
    }
]).controller("editCtrl", [
    "$scope", "$http", "$uibModalInstance", "$uibModal", "$common", "$window", ($scope, $http, $uibModalInstance, $uibModal, $common, $window) => {
        $scope.modalHeight = angular.element(window).height() - 230;
        $scope.item = angular.copy($scope.$resolve.resolveObj.item) || {};
        $scope.fkName = $scope.$resolve.resolveObj.fkName;
        $scope.gridOption = angular.extend({}, $scope.$resolve.resolveObj.gridOption);
        $scope.choose = (api) => {
            if ($scope.gridOption.selectedRow) {
                $uibModalInstance.close({
                    selected: $scope.gridOption.selectedRow,
                    api
                });
            } else
                $common.$toast.error($T.AlertSelect);
        }
        $scope.chooseObj = (template, field, name, bindName) => {
            $uibModal.open({
                windowTemplateUrl: "/ngTemplate/modal-template.html",
                templateUrl: template,
                controller: 'editCtrl',
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
            }).result.then(function (result) {
                $scope.item[field] = result.selected.Id;
                $scope.item[name] = result.selected[bindName];
            });
        }
        $scope.ok = (form, api) => {
            if (form.$invalid) {
                $common.$toast.error($T.FormValidateError);
                return;
            }
            let method = $scope.gridOption.itemFilterValue ? "edit" : "create";
            $http.post(api + method, $scope.item).success(function (result) {
                result.editObj = $scope.item;
                $uibModalInstance.close(result);
            })
        };
        $scope.scrollTo = targetSelection => {
            let top = angular.element(targetSelection).position().top;
            $scope.scrolls.updateScrollbar('scrollTo', top);
        };
        $scope.scrolls =
            {
                config: {
                    autoHideScrollbar: false,
                    theme: 'dark-3',
                    scrollInertia: 0,
                    axis: 'y'
                }
            }
        $scope.cancel = () => {
            $uibModalInstance.dismiss('cancel');
        };

    }
]).filter("filterColumn", () => (item, arrays) => {
    var obj = {};
    angular.forEach(item, (value, key) => {
        if ($.inArray(key, <any>arrays) === -1 && key.indexOf("$$") !== 0)
            obj[key] = value;
    });
    return obj;
});


