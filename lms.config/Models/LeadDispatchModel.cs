using System;
using lms.config.Models;

namespace lms.config.Models
{
    public class LeadDispatchModel
    {
        public long leadLogId { get; set; }

        public LeadRequestModel leadRequestModel { get; set; }

        public void Accept(long leadLogId, LeadRequestModel leadRequestModel)
        {
            this.leadLogId = leadLogId;
            this.leadRequestModel = leadRequestModel;
        }

    }

    
}

