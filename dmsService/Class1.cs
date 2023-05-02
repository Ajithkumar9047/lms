using DmsWebservice;

namespace dmsService;

public class Class1
{


    public async Task<string> check()
    {
       DmsWebservice.HOEnquirySoap DmsWebserviceSoapClient =
         new HOEnquirySoapClient(HOEnquirySoapClient.EndpointConfiguration.HOEnquirySoap);

       string Test = await DmsWebserviceSoapClient.SaveHOEnquiryAsync("", "HOAutoSense", "HOAutoT^$m");

        return "";
    }


}

