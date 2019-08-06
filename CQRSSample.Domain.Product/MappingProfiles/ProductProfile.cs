using AutoMapper;
using CQRSSample.Commands;

namespace CQRSSample.Domain.Product.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Models.Product>();
        }
    }
}
