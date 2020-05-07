using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using TechTalk.SpecFlow;
using TestProj.apiEngine;
using TestProj.Context;

namespace TestProj.Steps
{
    [Binding]
    public sealed class LoginToGameTwistSteps : BaseSteps
    {
        private readonly APITestContext context;

        [Given(@"I have the request ready")]
        public void GivenIHaveRequestReady()
        {
            if (context.getEndPoints().restRequest.Equals(null))

            {
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("endpoint has a value");
            }
        }


        public LoginToGameTwistSteps(APITestContext testContext)  : base(testContext)
        {
            this.context = testContext;
        }


        [Given(@"I execute login request with userId (.*) and password (.*)")]
        public void GivenIExecuteLoginRequestWithUserIdAndPassword(string nickname, string password)
        {
            LoginToGameTwist login = new LoginToGameTwist(nickname, password);
             context.getEndPoints().loginToGameTwist(login);
          
        }


       
        [Then(@"I verify response code is OK")]
        public void ThenTheResultShouldReturnResponse()
        {
            Assert.That(context.getEndPoints().response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        


    }
}
