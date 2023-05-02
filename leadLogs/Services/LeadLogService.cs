using System;
using lms.config.Models;
using leadReceiptService.Repository;
using Newtonsoft.Json;
using FluentValidation;
using FluentValidation.Results;
using leadReceiptService.Services;
using Constants = leadReceiptService.Const.Constants;

namespace leadReceiptService.Services
{
	public class LeadLogService: ILeadLogService
	{

        readonly IValidator<LeadRequestModel> validator;
        readonly ILeadDispatchService leadDispatchService;
        readonly IProcessInvalidLeadService processInvalidLeadService;
        readonly IProcessValidLeadService processValidLeadService;
        string message = "Success";


        public LeadLogService(IValidator<LeadRequestModel> validator, ILeadDispatchService leadDispatchService, IProcessInvalidLeadService processInvalidLeadService, IProcessValidLeadService processValidLeadService)
		{
            this.validator = validator;
            this.leadDispatchService = leadDispatchService;
            this.processInvalidLeadService = processInvalidLeadService;
            this.processValidLeadService = processValidLeadService;
        }

        public async Task<ServerResponse<long>> ProcessLead(LeadRequestModel leadRequestModel)
        {

            ValidationResult validateResult = validator.Validate(leadRequestModel);

            LeadLogModel leadLogModel = new LeadLogModel();

            var statusCode = StatusCodes.Status201Created;

            long result = 0;

            if (!validateResult.IsValid)
            {
                message = validateResult.ToString("~");

                await processInvalidLeadService.ProcessInValidLead(leadRequestModel, validateResult);

                statusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                result = await processValidLeadService.ProcessValidLead(leadRequestModel);
            }

            return new ServerResponse<long> { Message = message, Response = result, status = statusCode };
           
        }

    }
}

