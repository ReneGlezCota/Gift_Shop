using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Gift_Shop.Web.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    { 
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
    }
}