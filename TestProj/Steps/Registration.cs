using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestProj.Steps
{
    [Binding]
    public sealed class Registration
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

       // private readonly ScenarioContext context;

       /* public Registration(ScenarioContext injectedContext)
        {
            context = injectedContext;
        } */

        [Then(@"I build the upgrade to full registration post request using (.*), (.*), (.*) (.*), (.*), (.*) ,(.*) ,(.*) ,(.*) ,(.*), (.*)")]
        public void ThenIBuildTheUpgradeToFullRegistrationPostRequest(string firstName , string lastName, string male, string countryCode, string city, string zip,
            string street, int phonePrefix, string phoneNumber, string sec_ques, string sec_ans)
        {
            /*JObject jObjectbody = new JObject();
            jObjectbody.Add("firstName", firstName);
            jObjectbody.Add("lastName", lastName);
            jObjectbody.Add("isMale",male );
            jObjectbody.Add("countryCode", countryCode);
            jObjectbody.Add("city", city);
            jObjectbody.Add("zip",zip );
            jObjectbody.Add("street",street );
            jObjectbody.Add("phonePrefix",phonePrefix );
            jObjectbody.Add("phoneNumber",phoneNumber );
            jObjectbody.Add("securityQuestionTag", sec_ques);
            jObjectbody.Add("securityAnswer", sec_ans);

            RESTAPIHelper.UpgradeToFullRegistrationPostRequest(jObjectbody);*/
            RESTAPIHelper.UpgradeToFullRegistrationPostRequest(firstName, lastName,male,countryCode,city, zip, street, phonePrefix, phoneNumber, sec_ques, sec_ans);


        }

    }
}
