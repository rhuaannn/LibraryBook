using AutoMapper;
using LibraryDomain.DTOs;
using LibraryDomain.Entities;

namespace MyProject.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuração de mapeamento do AutoMapper
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
            CreateMap<BookDto, Book>();
        }
    }
}