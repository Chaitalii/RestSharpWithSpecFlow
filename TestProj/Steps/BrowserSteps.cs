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
            wait = new WebDriverWait(_webdrivercontext.driver, TimeSpan.FromSeconds(20));

        }


        [Given(@"I have navigated to paymentRedirectUrl")]
        public void GivenIHaveNavigatedToPaymentRedirectUrl()
        {
            _webdrivercontext.driver.Navigate().GoToUrl(Purchase.paymentRedirectUrl);
        }

               
        [Then(@"I click on Next button")]
        public void ThenIClickOnNextButton()
        {
            try
            {
               IWebElement element= _webdrivercontext.driver.FindElementByXPath("//button[contains(@id,'redirect')]");

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                element.Click();

            }
            catch(Exception e)
            {

                
                
            }
        }

        [Then(@"I select the bank")]
        public void ThenISelectTheBank()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//button[contains(@id,'redirect')]")));
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible
                    (By.Id("epsIssuerSelect")));
                SelectElement bank = new SelectElement(_webdrivercontext.driver.FindElement(By.Id("epsIssuerSelect")));
                bank.SelectByText("Bank Austria");
            }
            catch (Exception e)
            {

                //SelectElement bank = new SelectElement(_webdrivercontext.driver.FindElement(By.Id("epsIssuerSelect")));
                //bank.SelectByText("Bank Austria");
                throw e;
            }
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
           // IWebElement web=_webdrivercontext.driver.FindElementByXPath("//span[contains(text(), 'PIN falsch')]");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'PIN falsch')]")));
        }

        [Then(@"I click on Cancel button")]
        public void ThenIClickOnCancelButton()
        {
            _webdrivercontext.driver.FindElementByXPath("//a[span[span[contains(@class, 'logout')]]]").Click();
        }

        [Then(@"I take the screenshot")]
        public void ThenITakeTheScreenshot()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("nrgs-payment-status=error#returnUrl="));
            Screenshot ss = ((ITakesScreenshot)_webdrivercontext.driver).GetScreenshot();
            string title = "LoginFailed";
            string Runname = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
            string path = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(path+"//screenshots");
            path = path+"\\screenshots\\";
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
