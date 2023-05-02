using System;
using leadReceiptService.Const;
using lms.config.Models;
using leadReceiptService.Repository;
using Newtonsoft.Json;

namespace leadReceiptService.Services
{
	public class ProcessValidLeadService: IProcessValidLeadService
    {
        readonly ILeadLogRepository leadLogRepository;
        readonly ILeadDispatchService leadDispatchService;

        public ProcessValidLeadService(ILeadLogRepository leadLogRepository, ILeadDispatchService leadDispatchService)
		{
            this.leadLogRepository = leadLogRepository;
            this.leadDispatchService = leadDispatchService;

        }

        public async Task<long> ProcessValidLead(LeadRequestModel leadRequestModel)
        {
            LeadLogModel leadLogModel = new LeadLogModel();

            var requestJson = JsonConvert.SerializeObject(leadRequestModel);

            leadLogModel.LeadSource = leadRequestModel.Category;
            leadLogModel.Request = requestJson;

            var result = await leadLogRepository.CreateLeadLog(leadLogModel);

            LeadDispatchModel leadDispatchModel = new LeadDispatchModel();

            leadDispatchModel.Accept(result, leadRequestModel);

            await leadDispatchService.Dispatch(Constants.LEAD_TEMPLATE_QUEUE, JsonConvert.SerializeObject(leadDispatchModel));

            return result;
        }
    }
}

