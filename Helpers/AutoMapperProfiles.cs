using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Proveedor, ProveedorListDto>().ReverseMap();

            CreateMap<Proveedor, ProveedorAddDto>().ReverseMap();
        }
    }
}
