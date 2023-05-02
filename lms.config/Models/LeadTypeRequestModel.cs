using System;
namespace lms.config.Models
{
	public class LeadTypeRequestModel
	{
		public string api_key { get; set; }
        public string enq_datetime { get; set; }
        public string model_id { get; set; }
        public string part_id { get; set; }
        public string prospect_name { get; set; }
        public string prospect_mobile_no { get; set; }
        public string prospect_pincode { get; set; }
        public string dealer_pincode { get; set; }
        public string buy_date_range { get; set; }
        public string int_finance { get; set; }
        public string enq_source { get; set; }


        public void Accept()
        {

        }

    }

    public class LeadTypeResponseModel
    {
        public string retail_proba { get; set; }
        public string predicted_label { get; set; }
    }
}

