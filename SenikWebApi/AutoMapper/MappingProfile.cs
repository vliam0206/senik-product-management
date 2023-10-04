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
        CreateMap<Product, ProductModel>().ReverseMap();
        CreateMap<Product, ProductVM>().ReverseMap();
        CreateMap<Product, ProductOrderVM>().ReverseMap();
        CreateMap<Order, OrderVM>().ReverseMap();
        CreateMap<Order, OrderModel>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailModel>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailVM>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Product.Image))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Product.Category));                     
    }
}
