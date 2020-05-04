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


       

        













    }
}
