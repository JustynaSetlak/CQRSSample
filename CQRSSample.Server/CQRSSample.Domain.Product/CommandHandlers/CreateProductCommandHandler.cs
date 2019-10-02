using AutoMapper;
using CQRSSample.Commands;
using CQRSSample.Common.Handler;
using CQRSSample.Domain.Product.Interfaces;
using CQRSSample.Domain.Product.Models;
using CQRSSample.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSSample.CommandHandlers
{
    public class CreateProductCommandHandler : AsyncRequestHandler<CreateProductCommand>
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IMediator mediator, IProductRepository productRepository, IMapper mapper)
        {
            _mediator = mediator;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            request.Id = Guid.NewGuid();

            var productToAdd = _mapper.Map<Product>(request);
            productToAdd.CreatedAt = DateTime.UtcNow;

            var isSuccessfullResult = await _productRepository.CreateNewProduct(productToAdd);

            if (!isSuccessfullResult)
            {
                return;
            }

            var createProductCommandEvent = new NewProductAddedEvent(request.Id, request.Name, request.Description);
            await this._mediator.Publish(createProductCommandEvent);
        }
    }
}
