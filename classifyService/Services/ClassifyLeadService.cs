using System;
using System.Data;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using classifyService.Repository;
using lms.config.Models;
using Newtonsoft.Json;

namespace classifyService.Services
{
	public class ClassifyLeadService: IClassifyLeadService
	{
        readonly IClassifyRepository classifyRepository;

		public ClassifyLeadService(IClassifyRepository classifyRepository)
		{
            this.classifyRepository = classifyRepository;
		}

        public async Task ClassifyLead(LeadRequestModel leadRequestModel, long lead_id)
        {

            var dealerResult = await classifyRepository.GetDealer(Int32.Parse(leadRequestModel.DEALER_ID));

            LeadTypeRequestModel leadTypeRequestModel = new LeadTypeRequestModel();

            DateTime hotdate = Convert.ToDateTime(leadRequestModel.ENQUIRY_DATE.ToString());

            string date = hotdate.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            leadTypeRequestModel.api_key = "0526817fcef64110938ef2c19126bc17";
            leadTypeRequestModel.enq_datetime = date;
            leadTypeRequestModel.model_id = leadRequestModel.MODEL_ID;
            leadTypeRequestModel.part_id = leadRequestModel.PART_ID;
            leadTypeRequestModel.prospect_name = leadRequestModel.CUSTOMER_NAME;
            leadTypeRequestModel.prospect_mobile_no = leadRequestModel.MOBILE_NUMBER.Replace("+91", "");
            leadTypeRequestModel.prospect_pincode = leadRequestModel.pincode;
            leadTypeRequestModel.dealer_pincode = dealerResult.DealerPincode.ToString();
            leadTypeRequestModel.buy_date_range = leadRequestModel.IntentforPurchase;
            leadTypeRequestModel.int_finance = leadRequestModel.Finance;
            leadTypeRequestModel.enq_source = leadRequestModel.SOURCE;

            string request_json = JsonConvert.SerializeObject(leadTypeRequestModel);


            if (dealerResult != null)
            {

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://tvsmazlcedigitalappprod01.azurewebsites.net/api/lce/ho");
                var content = new StringContent(request_json, null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                if(response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    LeadTypeResponseModel leadTypeResponseModel = JsonConvert.DeserializeObject<LeadTypeResponseModel>(result);

                    await classifyRepository.InsertLeadType(leadTypeResponseModel, lead_id);

                }
               

                Console.WriteLine(await response.Content.ReadAsStringAsync());
                
            }

        }
    }
}

