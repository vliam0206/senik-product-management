using AutoMapper;
using Domain;
using SenikWebApi.Models;

namespace SenikWebApi.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterModel, Account>().ReverseMap();

    }
}
