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

        [Then(@"I build the upgrade to full registration post request using (.*), (.*)")]
        public void ThenIBuildTheUpgradeToFullRegistrationPostRequest(string firstName , string lastName)
        {


           /* , string male, string countryCode, string city, string zip,
            string street, int phonePrefix, string phoneNumber, string sec_ques, string sec_ans */
            JObject jObjectbody = new JObject();
            jObjectbody.Add("firstName", firstName);
            jObjectbody.Add("lastName", lastName);
            jObjectbody.Add("isMale",true );
            jObjectbody.Add("countryCode", "AT");
            jObjectbody.Add("city", "Vienna");
            jObjectbody.Add("zip","1050" );
            jObjectbody.Add("street","Test123" );
            jObjectbody.Add("phonePrefix",43 );
            jObjectbody.Add("phoneNumber","12345678" );
            jObjectbody.Add("securityQuestionTag", "squestion_make_of_first_car");
            jObjectbody.Add("securityAnswer", "Ferrari"); 

            RESTAPIHelper.UpgradeToFullRegistrationPostRequest(jObjectbody);
           // RESTAPIHelper.UpgradeToFullRegistrationPostRequest(firstName,lastName);


        }



       

       



    }
}
