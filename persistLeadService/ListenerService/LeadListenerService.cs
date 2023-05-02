using Microsoft.Azure.ServiceBus;
using System.Text;
using persistLeadService.Services;
using Constants = persistLeadService.Const.Constants;
using lms.config.Models;
using Newtonsoft.Json;

namespace persistLeadService.QueueListeners;

public class LeadListenerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IQueueClient queueClient = new QueueClient(Constants.SERVICE_BUS_ENDPOINT, Constants.LEAD_TEMPLATE_QUEUE);

    public LeadListenerService(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    private async Task Execute(Message message, CancellationToken token)
    {
        var lead = Encoding.UTF8.GetString(message.Body);

        LeadConsumeModel leadDispatchModel = JsonConvert.DeserializeObject<LeadConsumeModel>(lead);

        await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            ILeadService leadService =
                scope.ServiceProvider.GetRequiredService<ILeadService>();

            await leadService.LeadService(leadDispatchModel);
        }

    }

    private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
        Console.WriteLine($"Exception:: {exceptionReceivedEventArgs.Exception}.");
        return Task.CompletedTask;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
        {
            MaxConcurrentCalls = 1,
            AutoComplete = false,
            MaxAutoRenewDuration = TimeSpan.FromMinutes(1)
        };

        queueClient.RegisterMessageHandler(Execute, messageHandlerOptions);
        return Task.CompletedTask;
    }
    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        await queueClient.CloseAsync().ConfigureAwait(false);
    }
}

