using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Gift_Shop.Web.Mapping;

namespace Gift_Shop.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}