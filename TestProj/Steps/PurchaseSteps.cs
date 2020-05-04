using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestProj.apiEngine;
using TestProj.Context;

namespace TestProj.Steps
{
    [Binding]
    public sealed class PurchaseSteps : BaseSteps
    {
        
        public static string paymentRedirectUrl;

        private readonly APITestContext context;

        public PurchaseSteps(APITestContext testContext) : base(testContext)
        {
            this.context = testContext;
        }

        [Then(@"I execute post request for purchase for (.*), (.*), (.*), (.*)")]
        public void ThenIExecuteThePostRequestForPurchase(string item, string paymentTypeId, string country, string landingURL)
        {

             ItemPurchase purchase = new ItemPurchase(item, paymentTypeId,country,landingURL);
             context.getEndPoints().purchase(purchase);

           }

       
        [Then(@"I extract the value of paymentRedirectUrl")]
        public void ThenIExtractTheValueOfPaymentRedirectUrl()
        {
            JObject obj = JObject.Parse(context.getEndPoints().response.Content);
            paymentRedirectUrl = obj["paymentRedirectUrl"].ToString();
        }












    }
}
