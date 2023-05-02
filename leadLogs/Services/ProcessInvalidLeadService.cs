using System;
using FluentValidation;
using FluentValidation.Results;
using lms.config.Models;

using leadReceiptService.Repository;
using Newtonsoft.Json;

namespace leadReceiptService.Services
{
	public class ProcessInvalidLeadService: IProcessInvalidLeadService
	{
        readonly ILeadLogRepository leadLogRepository;

        public ProcessInvalidLeadService(ILeadLogRepository leadLogRepository)
		{
            this.leadLogRepository = leadLogRepository;
		}

        public async Task ProcessInValidLead(LeadRequestModel leadRequestModel, ValidationResult validateResult)
        {
            LeadLogModel leadLogModel = new LeadLogModel();

            leadLogModel.Error = true;

            var requestJson = JsonConvert.SerializeObject(leadRequestModel);

            leadLogModel.LeadSource = leadRequestModel.Category;
            leadLogModel.Request = requestJson;

            var result = await leadLogRepository.CreateLeadLog(leadLogModel);

            CreateErrorLog(validateResult, result);
        }

        public async void CreateErrorLog(ValidationResult validationResult, long leadLogId)
        {

            List<ErrorLeadModel> errorLeadModels = new List<ErrorLeadModel>();

            foreach (var failure in validationResult.Errors)
            {
                ErrorLeadModel errorLeadModel = new ErrorLeadModel();

                errorLeadModel.LeadLogId = leadLogId;
                errorLeadModel.ErrorDescription = failure.ErrorMessage;

                errorLeadModels.Add(errorLeadModel);

            }

            await leadLogRepository.CreateErrorLead(errorLeadModels);

        }

    }
}

