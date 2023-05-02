using System;
using FluentValidation;
using lms.config.Models;

namespace leadReceiptService.Services
{
	public class LeadLogValidator: AbstractValidator<LeadRequestModel>
	{
		public LeadLogValidator()
		{
            RuleFor(leadInput => leadInput).NotNull();
            RuleFor(leadInput => leadInput.CUSTOMER_NAME).NotNull().NotEmpty();
            RuleFor(leadInput => leadInput.MOBILE_NUMBER).NotNull().NotEmpty();
            RuleFor(leadInput => leadInput.ENQUIRY_DATE).NotNull().NotEmpty();
            RuleFor(leadInput => leadInput.brand_code).GreaterThan(0);
        }
	}
}

