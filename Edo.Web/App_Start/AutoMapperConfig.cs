using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edo.Data.Entity;
using Edo.ViewModels;

namespace Edo.Web
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderDetailsViewModel, OrderDetails>().ReverseMap()
                    .ForMember(v => v.ProductName, opt => opt.MapFrom(t => t.Products.ProductName))
                    .ForMember(v => v.OrderDate, opt => opt.MapFrom(t => t.Orders.OrderDate));

                cfg.CreateMap<OrdersViewModel, Orders>()
                    .ReverseMap()
                    .ForMember(v => v.CustomersCompanyAddress, opt => opt.MapFrom(t => t.Customers.Address))
                    .ForMember(v => v.CustomersCompanyName, opt => opt.MapFrom(t => t.Customers.CompanyName));

                cfg.CreateMap<RegionViewModel, Region>().ReverseMap()
                    .ForMember(v => v.Customers, opt => opt.Ignore());

                cfg.CreateMap<CustomersViewModel, Customers>().ReverseMap()
                    .ForMember(v => v.Regions, opt => opt.Ignore());
            });
        }
    }
}