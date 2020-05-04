using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
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
    public sealed class GetConsentType : BaseSteps
    {
        
        string ConsentAccepted;

        private readonly APITestContext context;

        public GetConsentType(APITestContext testContext) : base(testContext)
        {
            this.context = testContext;
        }


       

        [Given(@"I fetch the accepted value for (.*)")]
         public void GivenIFetchTheAcceptedValueForGeneralTermsAndConditions(string ConsentType)
        {
            Dictionary<string, string> Content = AcceptConsent.consentTypes;
            foreach (KeyValuePair<string, string> consent in Content)
            {
                if (consent.Key == ConsentType)
                {
                    ConsentAccepted = consent.Value;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }



        [Given(@"I validate the value of wasAccepted field")]
        public void GivenIValidateTheValueOfWasAcceptedField()
        {
            RESTAPIHelper helper = new RESTAPIHelper();
            string value = helper.GetValueFromDictionary(context.getEndPoints().response, "lastKnownConsent");
            JObject obj = JObject.Parse(value);
            var wasAccepted = obj["wasAccepted"].ToString().ToLower();
            Assert.That(wasAccepted, Is.EqualTo(ConsentAccepted));
        }


















    }
}
