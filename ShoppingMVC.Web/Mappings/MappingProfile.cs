using AutoMapper;
using ShoppingMVC.Entidades;
using ShoppingMVC.Web.ViewModels.Brand;
using ShoppingMVC.Web.ViewModels.Shoe;

namespace ShoppingMVC.Web.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadMappingBrand();
            LoadMappingShoe();
        }

        private void LoadMappingShoe()
        {
            CreateMap<Shoe, ShoeEditVM>().ReverseMap();

            CreateMap<Shoe, ShoeListVM>().ForMember(dest=> dest.BrandName, opt=>opt.MapFrom(b=>b.Brand!.BrandName)).ReverseMap();

        }

        private void LoadMappingBrand()
        {
            CreateMap<Brand, BrandEditVM>().ReverseMap();
            CreateMap<Brand, BrandListVM>();
        }
    }
}
