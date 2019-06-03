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
        public Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {   
            //get products from db
            throw new NotImplementedException();
        }
    }
}
