using AutoMapper;
using dbm.Api.DTO;
using dbm.Api.Models;


namespace dbm.Api.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}
