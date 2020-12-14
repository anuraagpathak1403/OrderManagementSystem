using AutoMapper;
using ORMModels.Models;
using ORMServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMServices.Mapping
{
    public class InventoryMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<InventoryModel, Inventory>();
            CreateMap<Inventory, InventoryModel>()
                .ForMember(item => item.inventoryAttachmentModel, o => o.Ignore());
        }
    }
}