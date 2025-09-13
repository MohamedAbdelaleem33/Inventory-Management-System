using AutoMapper;
using Inventory_Management_System.DTOs;
using Inventory_Management_System.Model;

namespace Inventory_Management_System.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product,ProductView>().ReverseMap();
        }
    }
}
