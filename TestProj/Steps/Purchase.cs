using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestProj.Steps
{
    [Binding]
    public sealed class Purchase
    {
        [Then(@"I build the post request for purchase for (.*), (.*), (.*), (.*)")]
        public void ThenIBuildThePostRequestForPurchase(string item, string paymentTypeId, string country, string landingURL)
        {
            JObject jobjectbody = new JObject();
            jobjectbody.Add("item", item);
            jobjectbody.Add("paymentTypeId", paymentTypeId);
            jobjectbody.Add("country", country);
            jobjectbody.Add("landingURL", landingURL);
            RESTAPIHelper.BuildPostRequest(jobjectbody);
        }

        [Given(@"I have purchase page endpoint to hit (.*)")]
        public void GivenIHavePurchasePageEndpointToHitPurchasePage(string endpoint)
        {
            RESTAPIHelper.SetPurchaseUrl(endpoint);
        }

        [Then(@"I extract the value of paymentRedirectUrl")]
        public void ThenIExtractTheValueOfPaymentRedirectUrl()
        {
            JObject obj = JObject.Parse(RESTAPIHelper.apiResponse.Content);
            RESTAPIHelper.paymentRedirectUrl = obj["paymentRedirectUrl"].ToString();
        }












    }
}
