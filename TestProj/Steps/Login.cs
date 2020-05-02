using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using TechTalk.SpecFlow;

namespace TestProj.Steps
{
    [Binding]
    public sealed class Login
    {
        [Given(@"I have endpoint to hit (.*)")]
        public void GivenIHaveEndpointToHitEndpoint(string endpoint)
        {
            RESTAPIHelper.SetUrl(endpoint);
        }

        [Given(@"I build login post request with (.*) and (.*)")]
        public void GivenIHitBuildLoginRequest(string nickname, string password)
        {
            RESTAPIHelper.CreateLoginRequest(nickname, password, true);
        }

        [Then(@"I hit the request")]
        public void ThenIHitTheRequest()
        {
            RESTAPIHelper.apiResponse = RESTAPIHelper.GetResponse();
        }



        [Then(@"I verify HTTP status code")]
        public void ThenTheResultShouldReturnResponse()
        {
            //Assert.IsTrue(RESTAPIHelper.apiResponse.StatusCode == System.Net.HttpStatusCode.OK, "Incorrect status code");
            var content = RESTAPIHelper.apiResponse.Content;
            Assert.That(RESTAPIHelper.apiResponse.StatusCode , Is.EqualTo(HttpStatusCode.OK));

        }
        [Then(@"I extract the token from the response")]
        public void ThenIextractTheToken()
        {
            RESTAPIHelper.ExtractToken(RESTAPIHelper.apiResponse);
        }

    }
}
