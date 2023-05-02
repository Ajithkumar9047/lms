using System;
using lms.config.Models;
using Newtonsoft.Json;
using lms.config.Utils;
using emsService.Repository;

namespace emsService.Services
{
	public class EmsService: IEmsService
	{

        readonly IEmsRepository emsRepository;

		public EmsService(IEmsRepository emsRepository)
		{
            this.emsRepository = emsRepository;
		}
         
        

        public async Task<EmsResponseModel> PushEmsLeads(LeadRequestModel leadRequestModel, long lead_id)
        {

            DateTime date = Convert.ToDateTime(leadRequestModel.ENQUIRY_DATE.ToString());

            string dateEms = date.ToString("yyyy-MM-ddTHH:mm:ss.000Z");

            EmsRequestModel emsRequest = new EmsRequestModel();

            emsRequest.DEALER_ID = leadRequestModel.DEALER_ID;
            emsRequest.BRANCH_ID = leadRequestModel.BRANCH_ID;
            emsRequest.INTERNET_ENQUIRY_ID = Util.GetTimestamp(DateTime.Now);
            emsRequest.CUSTOMER_NAME = leadRequestModel.CUSTOMER_NAME;
            emsRequest.AREA = leadRequestModel.AREA;
            emsRequest.PHONE_NUMBER = leadRequestModel.MOBILE_NUMBER.Replace("+91", "");
            emsRequest.MOBILE_NUMBER = leadRequestModel.MOBILE_NUMBER.Replace("+91", "");
            emsRequest.EMAIL_ID = leadRequestModel.EMAIL_ID;
            emsRequest.ENQUIRY_DATE = dateEms;
            emsRequest.MODEL_ID = leadRequestModel.MODEL_ID;
            emsRequest.PART_ID = leadRequestModel.PART_ID;
            emsRequest.CUSTOMER_VOICE = leadRequestModel.CUSTOMER_VOICE;
            emsRequest.IS_OPTED_FINANCE = leadRequestModel.Finance;
            emsRequest.SOURCE = leadRequestModel.SOURCE;

            string request_json = JsonConvert.SerializeObject(emsRequest);

            EmsResponseModel emsResponse = new EmsResponseModel();

            EmsLogModel emsLogModel = new EmsLogModel();

            emsLogModel.LeadId = lead_id;
            emsLogModel.Payload = request_json;
            emsLogModel.InternetEnquiryId = emsRequest.INTERNET_ENQUIRY_ID;


            var ems_id = await emsRepository.PushEmsLog(emsLogModel);


            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://www.api.tvsaccelerator.com/api/push-online-enquiry");
                request.Headers.Add("APIKey", "c60c2a641ba5a9f3bfdb5c18e80e9dfd456f41e708c69f07f6b2a0783dc680f9e672c8fec6dad544dc892a9004bb465daaa4cd8d89874cbcdfd920716b0f5315");
                var content = new StringContent(request_json, null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request); 
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                emsResponse = JsonConvert.DeserializeObject<EmsResponseModel>(result);

                if (response.IsSuccessStatusCode)
                {
                    UpdateEmsModel updateEmsModel = new UpdateEmsModel();

                    updateEmsModel.Id = ems_id;
                    updateEmsModel.Response = result;
                    updateEmsModel.Status = true;

                    await emsRepository.UpdateEmsLog(updateEmsModel);

                    if(emsResponse.status.Equals("Success"))
                    {

                    }

                }
                else
                {

                }

                

            }
            catch(Exception ex)
            {

            }

            return emsResponse;


        }

        
    }
}

