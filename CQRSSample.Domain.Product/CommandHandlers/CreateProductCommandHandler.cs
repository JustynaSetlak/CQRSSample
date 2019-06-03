using CQRSSample.Commands;
using CQRSSample.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSSample.CommandHandlers
{
    public class CreateProductCommandHandler : AsyncRequestHandler<CreateProductCommand>
    {
        private readonly IMediator mediator;

        public CreateProductCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected override Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // add product to db
            var createProductCommandEvent = new NewProductAddedEvent(request.Id, request.Name, request.Description);
            this.mediator.Publish(createProductCommandEvent);

            return Task.CompletedTask;
        }
    }
}
