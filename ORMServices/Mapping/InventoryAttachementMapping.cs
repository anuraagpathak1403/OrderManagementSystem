using AutoMapper;
using ORMModels.Models;
using ORMServices.Model;

namespace ORMServices.Mapping
{
    public class InventoryAttachementMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<InventoryAttachmentModel, InventoryAttachement>();
            CreateMap<InventoryAttachement, InventoryAttachmentModel>();
        }
    }
}