/******* 由模板生成*******/
var edo;
(function (edo) {
    var GridOption = (function () {
        function GridOption() {
        }
        GridOption.value = { "categories": { "columns": [{ "type": "Text", "field": "CategoryName", "id": "CategoryName", "name": "CategoryName", "sortable": true, "width": 150 }, { "type": "Text", "field": "Description", "id": "Description", "name": "Description", "sortable": true, "width": 150 }, { "type": "Text", "field": "Picture", "id": "Picture", "name": "Picture", "sortable": true, "width": 150 }], "btns": [{ "name": "Products", "template": "Products", "pk": "CategoryID" }] }, "customers": { "columns": [{ "type": "Text", "field": "CompanyName", "id": "CompanyName", "name": "CompanyName", "sortable": true, "width": 150 }, { "type": "Text", "field": "Address", "id": "Address", "name": "Address", "sortable": true, "width": 150 }, { "type": "Text", "field": "City", "id": "City", "name": "City", "sortable": true, "width": 150 }, { "type": "Text", "field": "Region", "id": "Region", "name": "Region", "sortable": true, "width": 150 }, { "type": "Text", "field": "Phone", "id": "Phone", "name": "Phone", "sortable": true, "width": 150 }], "btns": [{ "name": "Orders", "template": "Orders", "pk": "CustomerID" }, { "name": "Regions", "template": "Grid_Region", "pk": "Id" }] }, "employees": { "columns": [{ "type": "Text", "field": "LastName", "id": "LastName", "name": "LastName", "sortable": true, "width": 150 }, { "type": "Text", "field": "FirstName", "id": "FirstName", "name": "FirstName", "sortable": true, "width": 150 }, { "type": "Text", "field": "Address", "id": "Address", "name": "Address", "sortable": true, "width": 150 }, { "type": "Text", "field": "City", "id": "City", "name": "City", "sortable": true, "width": 150 }, { "type": "Text", "field": "Region", "id": "Region", "name": "Region", "sortable": true, "width": 150 }], "btns": [{ "name": "Orders", "template": "Orders", "pk": "EmployeeID" }] }, "orderDetails": { "columns": [{ "type": "Text", "field": "Products.ProductName", "id": "ProductName", "name": "ProductName", "sortable": true, "width": 150 }, { "type": "Number", "field": "UnitPrice", "id": "UnitPrice", "name": "UnitPrice", "sortable": true, "width": 150 }, { "type": "Number", "field": "Quantity", "id": "Quantity", "name": "Quantity", "sortable": true, "width": 150 }, { "type": "Number", "field": "Discount", "id": "Discount", "name": "Discount", "sortable": true, "width": 150 }], "btns": [] }, "orders": { "columns": [{ "type": "Text", "field": "Customers.CompanyName", "id": "CustomerName", "name": "CustomerName", "sortable": true, "width": 150 }, { "type": "Text", "field": "Shippers.CompanyName", "id": "ShippersName", "name": "ShippersName", "sortable": true, "width": 150 }, { "type": "Text", "field": "ShipName", "id": "ShipName", "name": "ShipName", "sortable": true, "width": 150 }, { "type": "Text", "field": "ShipAddress", "id": "ShipAddress", "name": "ShipAddress", "sortable": true, "width": 150 }, { "type": "Text", "field": "ShipCity", "id": "ShipCity", "name": "ShipCity", "sortable": true, "width": 150 }, { "type": "Date", "field": "OrderDate", "id": "OrderDate", "name": "OrderDate", "sortable": true, "width": 200 }, { "type": "Date", "field": "ShippedDate", "id": "ShippedDate", "name": "ShippedDate", "sortable": true, "width": 200 }], "btns": [{ "name": "OrderDetails", "template": "OrderDetails", "pk": "OrderID" }] }, "products": { "columns": [{ "type": "Text", "field": "ProductName", "id": "ProductName", "name": "ProductName", "sortable": true, "width": 150 }, { "type": "Text", "field": "Suppliers.CompanyName", "id": "SupplierName", "name": "SupplierName", "sortable": true, "width": 150 }, { "type": "Number", "field": "UnitPrice", "id": "UnitPrice", "name": "UnitPrice", "sortable": true, "width": 150 }, { "type": "Number", "field": "UnitsInStock", "id": "UnitsInStock", "name": "UnitsInStock", "sortable": true, "width": 150 }, { "type": "Number", "field": "UnitsOnOrder", "id": "UnitsOnOrder", "name": "UnitsOnOrder", "sortable": true, "width": 150 }], "btns": [{ "name": "OrderDetails", "template": "OrderDetails", "pk": "ProductID" }] }, "region": { "columns": [{ "type": "Text", "field": "RegionDescription", "id": "RegionDescription", "name": "RegionDescription", "sortable": true, "width": 150 }], "btns": [{ "name": "客户信息", "template": "Grid_Customers", "pk": "Id" }] }, "role": { "columns": [{ "type": "Text", "field": "Name", "id": "Name", "name": "Name", "sortable": true, "width": 150 }, { "type": "Text", "field": "Describe", "id": "Describe", "name": "Describe", "sortable": true, "width": 150 }], "btns": [{ "name": "Users", "template": "Grid_User", "pk": "Id" }] }, "shippers": { "columns": [{ "type": "Text", "field": "CompanyName", "id": "CompanyName", "name": "CompanyName", "sortable": true, "width": 150 }, { "type": "Text", "field": "Phone", "id": "Phone", "name": "Phone", "sortable": true, "width": 150 }], "btns": [{ "name": "Orders", "template": "Orders", "pk": "ShipperID" }] }, "suppliers": { "columns": [{ "type": "Text", "field": "CompanyName", "id": "CompanyName", "name": "CompanyName", "sortable": true, "width": 150 }, { "type": "Text", "field": "ContactName", "id": "ContactName", "name": "ContactName", "sortable": true, "width": 150 }, { "type": "Text", "field": "ContactTitle", "id": "ContactTitle", "name": "ContactTitle", "sortable": true, "width": 150 }, { "type": "Text", "field": "Address", "id": "Address", "name": "Address", "sortable": true, "width": 150 }, { "type": "Text", "field": "City", "id": "City", "name": "City", "sortable": true, "width": 150 }], "btns": [{ "name": "Products", "template": "Products", "pk": "SupplierID" }] }, "userPermission": { "columns": [{ "type": "Text", "field": "User.Name", "id": "UserName", "name": "UserName", "sortable": true, "width": 150 }, { "type": "Text", "field": "PermissionKey", "id": "PermissionKey", "name": "PermissionKey", "sortable": true, "width": 150 }], "btns": [] }, "user": { "columns": [{ "type": "Text", "field": "Name", "id": "Name", "name": "Name", "sortable": true, "width": 150 }, { "type": "Text", "field": "Email", "id": "Email", "name": "Email", "sortable": true, "width": 150 }, { "type": "Text", "field": "Mobile", "id": "Mobile", "name": "Mobile", "sortable": true, "width": 150 }, { "type": "Text", "field": "UserType", "id": "UserType", "name": "UserType", "sortable": true, "width": 150 }], "btns": [{ "name": "Roles", "template": "Grid_Role", "pk": "Id" }, { "name": "Permissions", "template": "UserPermission", "pk": "UserId" }] }, "userRole": { "columns": [], "btns": [] } };
        return GridOption;
    }());
    edo.GridOption = GridOption;
})(edo || (edo = {}));
//# sourceMappingURL=GridOptions.js.map