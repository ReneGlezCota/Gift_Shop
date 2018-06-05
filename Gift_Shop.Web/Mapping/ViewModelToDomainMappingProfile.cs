using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Gift_Shop.Entities;
using Gift_Shop.Web.ViewModels;

namespace Gift_Shop.Web.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    { 
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductFormViewModel, Product>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.ProductName))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.ProductDescription))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.ProductPrice))
                .ForMember(g => g.Imagepath, map => map.MapFrom(vm => vm.ProductFile))
                .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.ProductCategory));

            CreateMap<ProductFormUpdateViewModel, Product>()
                .ForMember(g => g.ProductID, map => map.MapFrom(vm => vm.ProductID))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.ProductName))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.ProductDescription))
                .ForMember(g => g.Price, map => map.MapFrom(vm => vm.ProductPrice))
                .ForMember(g => g.Imagepath, map => map.MapFrom(vm => vm.ProductFile))
                .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.ProductCategory));            
        }
    }
}