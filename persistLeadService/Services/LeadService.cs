using System;
using persistLeadService.Repository;
using lms.config.Models;
using classifyService.Services;
using emsService.Services;

namespace persistLeadService.Services;

public class LeadService: ILeadService
{
    readonly IClassifyLeadService classifyLeadService;
    readonly ILeadRepository leadRepository;
    private readonly ILogger<LeadService> _logger;
    readonly IEmsService emsService;

    public LeadService(IClassifyLeadService classifyLeadService, ILeadRepository leadRepository, ILogger<LeadService> logger, IEmsService emsService)
	{
        this.leadRepository = leadRepository;
        this._logger = logger;
        this.classifyLeadService = classifyLeadService;
        this.emsService = emsService;
    }

    async Task ILeadService.LeadService(LeadConsumeModel leadConsumeModel)
    {
        try
        {
            LeadModel leadModel = new LeadModel();

            leadModel.LeadLogId = leadConsumeModel.leadLogId;
            leadModel.ModelId = leadConsumeModel.leadRequestModel.MODEL_ID;
            leadModel.PartId = leadConsumeModel.leadRequestModel.PART_ID;
            leadModel.DealerId = leadConsumeModel.leadRequestModel.DEALER_ID;
            leadModel.IsFinance = leadConsumeModel.leadRequestModel.Finance == "1"? true: false ;

            var result = await leadRepository.CreateLead(leadModel);

            await classifyLeadService.ClassifyLead(leadConsumeModel.leadRequestModel, result);

            await emsService.PushEmsLeads(leadConsumeModel.leadRequestModel, result);


        }
        catch(Exception ex)
        {
            _logger.LogError("Failed to Process Lead", ex);
        }
    }
}


