using System;
using FluentValidation.Results;
using lms.config.Models;

namespace leadReceiptService.Services
{
	public interface IProcessInvalidLeadService
	{
        Task ProcessInValidLead(LeadRequestModel leadRequestModel, ValidationResult validateResult);
    }
}

