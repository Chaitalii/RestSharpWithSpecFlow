using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TestProj.Context;
using TestProj.Steps;

namespace TestProj
{
    [Binding]
    public class BrowserSteps : IDisposable
    {
       
        WebDriverWait wait;
        
        private readonly BrowserContext _webdrivercontext;

        public BrowserSteps(BrowserContext webdrivercontext)
        {
           
            this._webdrivercontext = webdrivercontext;
            _webdrivercontext.driver.Manage().Window.Maximize();
            wait = new WebDriverWait(_webdrivercontext.driver, TimeSpan.FromSeconds(10));

        }


        [Given(@"I have navigated to paymentRedirectUrl")]
        public void GivenIHaveNavigatedToPaymentRedirectUrl()
        {
            _webdrivercontext.driver.Navigate().GoToUrl(Purchase.paymentRedirectUrl);
        }

        [Given(@"I wait until Next button is displayed")]
        public void GivenIWaitUntilNextButtonIsDisplayed()
        {
            
            try
            {
                //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[span(contains(text(), 'Next'))]")));
                //_webdrivercontext.driver.FindElement(By.XPath("//button[contains(@title, 'will be')]"));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        
        [Then(@"I click on Next button")]
        public void ThenIClickOnNextButton()
        {
            try
            {
                _webdrivercontext.driver.FindElementByXPath("//button[span(contains(text(), 'Next'))]").Click();
            }
            catch(Exception e)
            {

                _webdrivercontext.driver.FindElementByXPath("//button[contains(@id,'redirect')]").Click();
                
            }
        }

        [Then(@"I select the bank")]
        public void ThenISelectTheBank()
        {
            
            SelectElement oSelect = new SelectElement(_webdrivercontext.driver.FindElement(By.Id("epsIssuerSelect")));
            oSelect.SelectByText("Bank Austria");
        }

        [Then(@"I click on Continue button")]
        public void ThenIClickOnContinueButton()
        {
            _webdrivercontext.driver.FindElementById("mainSubmit").Click();
        }

        [Then(@"I add random values to the two input boxes")]
        public void ThenIAddRandomValuesToTheTwoInputBoxes()
        {

            _webdrivercontext.driver.FindElementById("gebForm:verf_ID").SendKeys("test");

            _webdrivercontext.driver.FindElementById("gebForm:pin_ID").SendKeys("test");

             }

        [Then(@"I click on the login button")]
        public void ThenIClickOnTheLoginButton()
        {
            _webdrivercontext.driver.FindElementById("gebForm:LoginCommandButton").Click();
        }

        [Then(@"I verify the failure message")]
        public void ThenIVerifyTheFailureMessage()
        {
            IWebElement web=_webdrivercontext.driver.FindElementByXPath("//span[contains(text(), 'PIN falsch')]");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(web,"PIN"));
        }

        [Then(@"I click on Cancel button")]
        public void ThenIClickOnCancelButton()
        {
            _webdrivercontext.driver.FindElementByXPath("//a[span[span[contains(@class, 'logout')]]]").Click();
        }

        [Then(@"I take the screenshot")]
        public void ThenITakeTheScreenshot()
        {

            System.Threading.Thread.Sleep(4000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("nrgs-payment-status=error#returnUrl="));
            Screenshot ss = ((ITakesScreenshot)_webdrivercontext.driver).GetScreenshot();
            string title = "LoginFailed";
            string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string path = Directory.GetCurrentDirectory();
            path = "C:\\Users\\Oli\\screenshots\\";
            string screenshotfilename = path+ Runname + ".jpg";
            ss.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Png);
        }

        [Then(@"I close the browser")]
        public void ThenICloseTheBrowser()
        {
            _webdrivercontext.driver.Close();
        }
        public void Dispose()
        {
            if (_webdrivercontext.driver != null)

            {
                _webdrivercontext.driver.Dispose();
                _webdrivercontext.driver = null;
            }
        }

    }
}
