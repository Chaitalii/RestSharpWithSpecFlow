using Newtonsoft.Json.Linq;
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
    public sealed class FullRegistration : BaseSteps
    {
        private readonly Context.APITestContext context;

        public FullRegistration(APITestContext testContext) : base(testContext)
        {
            this.context = testContext;
        }

      

        [Then(@"I execute UpgradeToFullRegistrationGT request using (.*),(.*),(.*),(.*),(.*),(.*),(.*),(\d+),(.*),(.*),(.*)")]
        public void ThenIExecuteUpgradeToFullRegistrationGTRequest(string s1, string s2, bool s3, string s4, string s5, string s6, string s7, int p1, string s9, string s10, string s11)
        {
            UpgradeToFullRegistration upgrade = new UpgradeToFullRegistration(s1, s2, s3, s4, s5, s6, s7, p1, s9, s10, s11);
            context.getEndPoints().upgradeToFullRegistrationGT(upgrade);
        }



    }
}
