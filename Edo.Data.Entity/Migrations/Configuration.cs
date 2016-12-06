using System.Collections.Generic;

namespace Edo.Data.Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EdoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Edo.Data.Entity.EdoDbContext";
        }

        protected override void Seed(Edo.Data.Entity.EdoDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Region.AddOrUpdate(new Region
            {
                Id = Guid.Parse("8247EC3E-F158-4962-AC6C-A6CC00F2E4E8"),
                RegionDescription = "华南区"
            }, new Region
            {
                Id = Guid.Parse("8257EC3E-F158-4962-AC6C-A6CC00F2E4E8"),
                RegionDescription = "华北区"
            }, new Region
            {
                Id = Guid.Parse("8347EC3E-F158-4962-AC6C-A6CC00F2E4E8"),
                RegionDescription = "西南区"
            });
            context.Employees.AddOrUpdate(new Employees
            {
                Id = Guid.Parse("8547EC3E-F158-4962-AC6C-A6CC00F2E6E8"),
                City = "ShangHai",
                Address = "ShangHai,PuDong",
                HomePhone = "13534138255",
                Country = "CN",
                BirthDate = DateTime.Parse("1983-03-11")
            });
            context.Customers.AddOrUpdate(new Customers
            {
                Id = Guid.Parse("8547EC3E-F158-4962-AC6C-A6CC00F2E6E9"),
                City = "ShangHai",
                Address = "ShangHai JiaDing",
                CompanyName = "SanSing",
                Country = "CN",
                Phone = "25667822"
            }, new Customers
            {
                Id = Guid.Parse("8547EC3E-F158-4962-AC6C-A6CC10F2E6E8"),
                City = "ShenZhen",
                Regions = new List<Region>
                {
                new Region {
                Id = Guid.Parse("8347EC3E-F158-4942-AC6C-A6CC00F2E4E8"),
                RegionDescription = "东南区"
                 },
                  new Region {
                Id = Guid.Parse("8347EC3E-F158-4963-AC6C-A6CC00F2E4E8"),
                RegionDescription = "东北区"
                 }
                },
                Address = "ShenZhen BaoAn",
                CompanyName = "Lus",
                Country = "CN",
                Phone = "12345678"
            });

            context.Shippers.AddOrUpdate(new Shippers
            {
                Id = Guid.Parse("8545EC3E-F158-4962-AC6C-A6CC00F2E5E9"),
                CompanyName = "SanGo",
                Phone = "13534138066"
            });
            context.Suppliers.AddOrUpdate(new Suppliers
            {
                Id = Guid.Parse("8247EC3E-F158-4962-AC6C-A6CC00F2E6E8"),
                Address = "ShangHai,PuDong,No.112",
                City = "ShangHai",
                CompanyName = "CNN",
                ContactName = "EDO",
                ContactTitle = "Edo",
                Country = "CN"
            });
            context.Categories.AddOrUpdate(new Categories
            {
                Id = Guid.Parse("BBAEC801-80C9-4CD0-9886-A6CC00F642AF"),
                CategoryName = "PaPer",
                Description = "Paper"
            });
            context.Products.AddOrUpdate(new Products
            {
                Id = Guid.Parse("29CC3051-E2ED-46A7-9351-A6CC00FB5F92"),
                ProductName = "Worth Map",
                UnitPrice = 12,
                ReorderLevel = 1,
                Discontinued = true,
                QuantityPerUnit = "A",
                SupplierID = Guid.Parse("8247EC3E-F158-4962-AC6C-A6CC00F2E6E8"),
                CategoryID = Guid.Parse("BBAEC801-80C9-4CD0-9886-A6CC00F642AF")

            });

            context.Orders.AddOrUpdate(new Orders
            {
                Id = Guid.Parse("DDAEC801-80C9-4CD0-9886-A6CC00F643DF"),
                ShipperID = Guid.Parse("8545EC3E-F158-4962-AC6C-A6CC00F2E5E9"),
                CustomerID = Guid.Parse("8547EC3E-F158-4962-AC6C-A6CC00F2E6E9"),
                EmployeeID = Guid.Parse("8547EC3E-F158-4962-AC6C-A6CC00F2E6E8"),
                Freight = 1000,
                ShipCountry = "ShangHai",
                ShipAddress = "ShangHai YangLing Road.1123",
                ShipCity = "ShangHai PuDong",
                ShipName = "SanXing",
                OrderDate = DateTime.Parse("2016-03-11"),
            }, new Orders
            {
                Id = Guid.Parse("DDAEC801-80C9-4CD0-9886-A6CC00F644DF"),
                ShipperID = Guid.Parse("8545EC3E-F158-4962-AC6C-A6CC00F2E5E9"),
                CustomerID = Guid.Parse("8547EC3E-F158-4962-AC6C-A6CC00F2E6E8"),
                EmployeeID = Guid.Parse("8547EC3E-F158-4962-AC6C-A6CC00F2E6E8"),
                Freight = 1000,
                ShipCountry = "shengZhenChengDe",
                ShipAddress = "shengZhenChengDe YangLing Road.1123",
                ShipCity = "shengZhenChengDe PuDong",
                ShipName = "Nacl",
                OrderDate = DateTime.Parse("2016-04-12"),
                OrderDetails = new List<OrderDetails>
                {
                    new OrderDetails{ 
                        Discount=122, 
                        OrderID=Guid.Parse("DDAEC801-80C9-4CD0-9886-A6CC00F643DF"), 
                        ProductID= Guid.Parse("29CC3051-E2ED-46A7-9351-A6CC00FB5F92"),
                       Quantity=12,
                       UnitPrice=33,
                       CreatedDate=DateTime.Now                  
                    }
                }
            });
        }
    }
}
