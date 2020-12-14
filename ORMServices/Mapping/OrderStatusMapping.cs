using AutoMapper;
using ORMModels.Models;
using ORMServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMServices.Mapping
{
    public class OrderStatusMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<OrderStatusModel, OrderStatus>()
                .ForMember(item => item.Customers, o => o.Ignore())
                    .ForMember(item => item.SalesManInfo, o => o.Ignore())
                    .ForMember(item => item.Inventory, o => o.Ignore())
                    .ForMember(item => item.StatusMaster, o => o.Ignore());
            CreateMap<OrderStatus, OrderStatusModel>()
                .ForMember(item => item.customerOrderStatusModel, o => o.Ignore())
                .ForMember(d => d.SalesManFullName, o => o.MapFrom(item => item.SalesManInfo.FirstName + " " + item.SalesManInfo.LastName))
                .ForMember(d => d.CustomerFullName, o => o.MapFrom(item => item.Customers.FirstName + " " + item.Customers.LastName))
                .ForMember(d => d.CurrentStatus, o => o.MapFrom(item => item.StatusMaster.StatusName))
                .ForMember(d => d.InventoryName, o => o.MapFrom(item => item.Inventory.InventoryName));
        }
    }
}