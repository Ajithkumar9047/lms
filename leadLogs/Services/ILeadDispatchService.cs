using System;
namespace leadReceiptService.Services
{
	public interface ILeadDispatchService
	{
        public Task Dispatch(string queueName, string message);
    }
}

