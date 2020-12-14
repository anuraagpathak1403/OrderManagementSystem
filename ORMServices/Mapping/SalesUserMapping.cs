using System;
using AutoMapper;
using ORMModels.Models;
using ORMServices.Model;

namespace ORMServices.Mapping
{
    public class SalesUserMapping : Profile
    {
        protected override void Configure()
        {
            CreateMap<SalesUserModel, SalesManInfo>();
            CreateMap<SalesManInfo, SalesUserModel>();
        }
    }
}