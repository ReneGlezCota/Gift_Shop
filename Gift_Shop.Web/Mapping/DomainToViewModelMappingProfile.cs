using AutoMapper;
using Gift_Shop.Entities;
using Gift_Shop.Web.ViewModels;

namespace Gift_Shop.Web.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<User, UserViewModel>();
        }
    }
}