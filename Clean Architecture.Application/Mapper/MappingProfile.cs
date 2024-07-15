

using AutoMapper;
using Clean_Architecture.Application.DTOs;
using Clean_Architecture.core.Entities;

namespace Clean_Architecture.Application.Mapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Product, ProductDisplayDTO>()
            .ForMember(dest => dest.categoryName, opt => opt.MapFrom(src => src.Category.Name));


        }


    }
}
