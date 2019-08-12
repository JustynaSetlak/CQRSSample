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
using Microsoft.Extensions.Options;
using CQRSSample.Common.Configuration;
using Microsoft.Extensions.Logging;

namespace CQRSSample.Domain.Customer.EventHandlers
{
    public class NewProductAddedEventHandler : INotificationHandler<NewProductAddedEvent>
    {
        private readonly IMessageSender _messageSender;
        private readonly ILogger _logger;
        private readonly CustomerNotificationConfiguration _customerNotificationConfiguration;

        public NewProductAddedEventHandler(
            IMessageSender messageSender, 
            IOptions<CustomerNotificationConfiguration> customerNotificationConfigurationAccessor,
            ILogger<NewProductAddedEventHandler> logger)
        {
            _messageSender = messageSender;
            _logger = logger;
            _customerNotificationConfiguration = customerNotificationConfigurationAccessor.Value;
        }

        public async Task Handle(NewProductAddedEvent newProductAdded, CancellationToken cancellationToken)
        {
            try
            {
                var message = new MessageDto
                {
                    To = _customerNotificationConfiguration.EmailAddress,
                    Subject = $"New product added: {newProductAdded.Name}",
                    Content = $"Description: {newProductAdded.Description}"
                };

                var serializedMessage = JsonConvert.SerializeObject(message);

                var messageToSent = new Message(Encoding.UTF8.GetBytes(serializedMessage))
                {
                    CorrelationId = newProductAdded.Id.ToString(),
                };

                await _messageSender.SendAsync(messageToSent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }
    }
}
