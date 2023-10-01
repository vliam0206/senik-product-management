using AutoMapper;
using Domain;
using SenikWebApi.Models;

namespace SenikWebApi.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterModel, Account>().ReverseMap();
        CreateMap<RegisterModel, CustomerInfor>().ReverseMap();
        CreateMap<CustomerInfor, CustomerInforVM>().ReverseMap();
        CreateMap<Account, AccountVM>()
            .ForMember(dest => dest.Informations, opt => opt.MapFrom(src => src.CustomerInfor));

    }
}
