using AutoMapper;
using Domain;
using SenikWebApi.Models;

namespace SenikWebApi.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Account, RegisterModel>().ReverseMap();
        CreateMap<Account, AccountModel>().ReverseMap();
        CreateMap<Account, AccountVM>().ReverseMap();
    }
}
