using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestProj.Steps
{
    [Binding]
    public class VerifyConsentSteps
    { 
         public static Dictionary<string, string> consentTypes;
        public static string ConsentAccepted;

    static VerifyConsentSteps()
    {
            consentTypes = new Dictionary<string, string>();
            
        }
    
        [Given(@"I build consent type post request for consent type (.*) and accepted value as (.*)")]
        public void GivenIBuildConsentTypePostRequestForConsentTypeGeneralTermsAndConditionsAndAcceptedValueAsTrue(string ConsentType, string Accepted)
        {
            RESTAPIHelper.CreatePostConsentRequest(ConsentType, Accepted);
        }


        [Given(@"I build consent type get request for consent type (.*)")]
        public void GivenIBuildConsentTypePostRequestForConsentType(string ConsentType)
        {
            RESTAPIHelper.CreateGetConsentRequest(ConsentType);
        }

        [Given(@"I store the (.*) and accepted (.*)")]
        public void GivenIStoreTheConsentTypeAndAcceptedValue(string ConsentType, string value)
        {
            RESTAPIHelper res = new RESTAPIHelper();
            // RESTAPIHelper.storeValuesinDictionary(ConsentType,value);
            consentTypes.Add(ConsentType, value);

        }



       /* [Given(@"I fetch values from dictionary")]
        public void GivenIFetchValuesFromDictionary()
        {
            string accepted = RESTAPIHelper.GetValueFromDictionary(consentTypes, );
        }*/

        [Then(@"I fetch the accepted value for (.*)")]
        public void ThenIFetchTheAcceptedValueForGeneralTermsAndConditions(string ConsentType)
        {
             ConsentAccepted=RESTAPIHelper.GetValueFromDictionary(consentTypes, ConsentType);
            ThenIValidateTheValueOfWasAcceptedField();
        }










        [Then(@"I validate the value of wasAccepted field")]
        public void ThenIValidateTheValueOfWasAcceptedField()
        {
           string value= RESTAPIHelper.GetValueFromDictionary("lastKnownConsent");
            JObject obj = JObject.Parse(value);
            var wasAccepted = obj["wasAccepted"].ToString().ToLower();
            
            Assert.That(wasAccepted, Is.EqualTo(ConsentAccepted));
        }
    }

}
