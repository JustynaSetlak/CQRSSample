using CQRSSample.Events;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CQRSSample.Domain.Customer.Dtos;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus;

namespace CQRSSample.Domain.Customer.EventHandlers
{
    public class NewProductAddedEventHandler : INotificationHandler<NewProductAddedEvent>
    {
        private readonly IMessageSender _messageSender;

        public NewProductAddedEventHandler(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public async Task Handle(NewProductAddedEvent newProductAdded, CancellationToken cancellationToken)
        {
            //send email to the customer //

            try
            {
                var messageDto = new MessageDto
                {
                    To = "justa96.s1@gmail.com",
                    Subject = $"New product added - {newProductAdded.Name}",
                    Content = $"Description {newProductAdded.Description}"
                };

                var serializedMessage = JsonConvert.SerializeObject(messageDto);

                var message = new Message(Encoding.UTF8.GetBytes(serializedMessage))
                {
                    CorrelationId = newProductAdded.Id.ToString(),
                };

                await _messageSender.SendAsync(message);
            }
            catch (Exception ex)
            {
                //log exception
            }

        }
    }
}
