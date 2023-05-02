using System;
using leadReceiptService.Services;
using Azure.Messaging.ServiceBus;
using Constants = leadReceiptService.Const.Constants;

namespace leadReceiptService.Services
{
	public class LeadDispatchService: ILeadDispatchService
	{
        private readonly ServiceBusClient client = new(Constants.SERVICE_BUS_ENDPOINT);
        public async Task Dispatch(string queueName, string message)
        {
            var sender = client.CreateSender(queueName);
            var busMessage = new ServiceBusMessage(message);
            await sender.SendMessageAsync(busMessage);
        }
    }
}

