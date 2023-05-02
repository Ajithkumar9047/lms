using System;
using classificationService.Repository;
using lms.config.Models;

namespace classificationService.Services
{
	public class ClassifyLeadService: IClassifyLeadService
	{
        readonly IClassifyRepository classifyRepository;

		public ClassifyLeadService(IClassifyRepository classifyRepository)
		{
            this.classifyRepository = classifyRepository;
		}

        public async Task ClassifyLead(LeadRequestModel leadRequestModel)
        {

            var result = await classifyRepository.GetDealer(Int32.Parse(leadRequestModel.DEALER_ID));

            if(result != null)
            {

            }

        }
    }
}

