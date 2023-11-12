using AutoMapper;
using Domain;
using Newtonsoft.Json;
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
        CreateMap<Order, OrderVM>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderDetails));
        CreateMap<Order, OrderModel>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailModel>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailVM>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Product.Image))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Product.Category));

        // map order - order report vm
        CreateMap<Order, OrderReportVM>()
    .ForMember(dest => dest.Items, opt => opt.MapFrom(src =>
        JsonConvert.SerializeObject(src.OrderDetails.Select(od => new
        {
            ProductName = od.Product.Name, // Replace with actual property name
            UnitPrice = od.UnitPrice,
            Quantity = od.Quantity,       // Replace with actual property name
            // Add other properties as needed
        }))));
    }
}
