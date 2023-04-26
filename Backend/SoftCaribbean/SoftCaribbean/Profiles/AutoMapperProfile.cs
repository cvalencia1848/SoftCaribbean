using AutoMapper;
using SoftCaribbean.DTOs;
using SoftCaribbean.Models;

namespace SoftCaribbean.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PersonaDTo, Persona>();
            CreateMap<Persona, PersonaDTo>();
            CreateMap<Genero, GeneroDTo>();
        }
    }
}
