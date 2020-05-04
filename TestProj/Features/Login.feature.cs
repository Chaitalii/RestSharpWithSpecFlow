// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestProj.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Login")]
    public partial class LoginFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Login.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Login", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("1 Verify login is successful with valid username and password")]
        [NUnit.Framework.TestCaseAttribute("/login-v1/", "Testing768", "Welcome_2_gametwist", null)]
        public virtual void _1VerifyLoginIsSuccessfulWithValidUsernameAndPassword(string endpoint, string userId, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("1 Verify login is successful with valid username and password", null, exampleTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
 testRunner.And(string.Format("I execute login request with userId {0} and password {1}", userId, password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 6
 testRunner.Then("I verify response code is OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("2 Validate logged in user is able to send consent types")]
        [NUnit.Framework.TestCaseAttribute("GeneralTermsAndConditions", "true", null)]
        [NUnit.Framework.TestCaseAttribute("DataPrivacyPolicy", "true", null)]
        [NUnit.Framework.TestCaseAttribute("MarketingProfiling", "true", null)]
        public virtual void _2ValidateLoggedInUserIsAbleToSendConsentTypes(string consentType, string accepted, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("2 Validate logged in user is able to send consent types", null, exampleTags);
#line 12
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 15
 testRunner.And(string.Format("I execute post request for given consent type {0} and accepted value as {1}", consentType, accepted), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("I store the {0} and accepted {1}", consentType, accepted), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.Then("I verify response code is OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("3 Validate  GET Consent-v1 API")]
        [NUnit.Framework.TestCaseAttribute("GeneralTermsAndConditions", null)]
        [NUnit.Framework.TestCaseAttribute("MarketingProfiling", null)]
        [NUnit.Framework.TestCaseAttribute("DataPrivacyPolicy", null)]
        public virtual void _3ValidateGETConsent_V1API(string consentType, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("3 Validate  GET Consent-v1 API", null, exampleTags);
#line 25
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 27
 testRunner.And(string.Format("I execute get request for consent type {0}", consentType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And(string.Format("I fetch the accepted value for {0}", consentType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I validate the value of wasAccepted field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("5 POST Purchase-v1 API")]
        [NUnit.Framework.TestCaseAttribute("m", "adyenEPS", "AT", "https://www.gametwist.com/en/?modal=shop", null)]
        public virtual void _5POSTPurchase_V1API(string item, string paymentTypeId, string country, string landingURl, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("5 POST Purchase-v1 API", null, exampleTags);
#line 38
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 40
testRunner.Then(string.Format("I execute post request for purchase for {0}, {1}, {2}, {3}", item, paymentTypeId, country, landingURl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.Then("I verify response code is OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
testRunner.And("I extract the value of paymentRedirectUrl", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("6 Login to browser")]
        public virtual void _6LoginToBrowser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("6 Login to browser", null, ((string[])(null)));
#line 52
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 53
testRunner.Given("I have navigated to paymentRedirectUrl", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
testRunner.Then("I click on Next button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.And("I select the bank", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
testRunner.Then("I click on Continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
testRunner.And("I add random values to the two input boxes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
testRunner.Then("I click on the login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.Then("I verify the failure message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
testRunner.And("I click on Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.Then("I take the screenshot", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("4 POST UpgradeToFullRegistrationGT-v1 API")]
        [NUnit.Framework.TestCaseAttribute("Jayashree", "Dey", "true", "AT", "Vienna", "1050", "Wiedner Hauptstraße 94", "43", "12345678", "squestion_make_of_first_car", "Ferrari", null)]
        public virtual void _4POSTUpgradeToFullRegistrationGT_V1API(string firstName, string lastName, string isMale, string countryCode, string city, string zip, string street, string phonePrefix, string phoneNumber, string securityQuestionTag, string securityAnswer, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("4 POST UpgradeToFullRegistrationGT-v1 API", null, exampleTags);
#line 66
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 68
 testRunner.Then(string.Format("I execute UpgradeToFullRegistrationGT request using {0},{1},{2},{3},{4},{5},{6},{" +
                        "7},{8},{9},{10}", firstName, lastName, isMale, countryCode, city, zip, street, phonePrefix, phoneNumber, securityQuestionTag, securityAnswer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
 testRunner.Then("I verify response code is OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
