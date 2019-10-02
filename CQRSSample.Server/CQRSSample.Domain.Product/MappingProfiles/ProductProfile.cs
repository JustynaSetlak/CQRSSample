using AutoMapper;
using CQRSSample.Commands;
using CQRSSample.Dtos;

namespace CQRSSample.Domain.Product.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Models.Product>();

            CreateMap<Models.Product, ProductDto>();
        }
    }
}
