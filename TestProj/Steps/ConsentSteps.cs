using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestProj.apiEngine;
using TestProj.Context;

namespace TestProj.Steps
{
    [Binding]
    public class ConsentSteps : BaseSteps
    { 
        public static Dictionary<string, string> consentTypes;
        public static string ConsentAccepted;

        private readonly APITestContext context;
        static ConsentSteps()
         {
            consentTypes = new Dictionary<string, string>();
         }
       

        public ConsentSteps(APITestContext testContext) : base(testContext)
        {
            this.context = testContext;
        }

        [Given(@"I execute post request for given consent type (.*) and accepted value as (.*)")]
        public void GivenIExecuteRequestForGivenConsentType(string cosentType, string value)
        {
           
            ConsentAcceptance consent = new ConsentAcceptance(cosentType, value);
            context.getEndPoints().postConsent(consent);
        }

        [Then(@"I verify acceptance status is set successfully")]
        public void ThenIVerifyAcceptanceStatusIsSetSuccessfully()
        {
            Assert.That(context.getEndPoints().response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


        [Given(@"I store the (.*) and accepted (.*)")]
        public void GivenIStoreTheConsentTypeAndAcceptedValue(string ConsentType, string value)
        {
            RESTAPIHelper res = new RESTAPIHelper();
            consentTypes.Add(ConsentType, value);

        }


        [Given(@"I execute get request for consent type (.*)")]
        public void GivenIExecuteGetRequestForConsentType(string consentType)
        {
           
            CurrentAcceptanceStatus consentStatus = new CurrentAcceptanceStatus(consentType);
          
             context.getEndPoints().getConsent(consentStatus);
        }

        [Given(@"I fetch the accepted value for (.*)")]
        public void GivenIFetchTheAcceptedValueForGeneralTermsAndConditions(string ConsentType)
        {
            Dictionary<string, string> Content = ConsentSteps.consentTypes;
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
