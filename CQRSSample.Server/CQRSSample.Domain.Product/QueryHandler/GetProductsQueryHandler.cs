using AutoMapper;
using CQRSSample.Domain.Product.Interfaces;
using CQRSSample.Dtos;
using CQRSSample.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSSample.Domain.Product.QueryHandler
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetProducts();
            var productsResult = _mapper.Map <List<ProductDto>>(products);

            return Task.FromResult(productsResult);
        }
    }
}
