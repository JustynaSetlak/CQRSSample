using CQRSSample.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSSample.Domain.Customer.EventHandlers
{
    internal class NewProductAddedEventHandler : INotificationHandler<NewProductAddedEvent>
    {
        public Task Handle(NewProductAddedEvent notification, CancellationToken cancellationToken)
        {
            //send email to the customer //
            throw new NotImplementedException();
        }
    }
}
