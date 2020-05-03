using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace TestProj
{
    [Binding]
    public class BrowserSteps : IDisposable
    {
        private ChromeDriver chromeDriver;
        WebDriverWait wait;


        public BrowserSteps()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));

        }


        [Given(@"I have navigated to paymentRedirectUrl")]
        public void GivenIHaveNavigatedToPaymentRedirectUrl()
        {
            chromeDriver.Navigate().GoToUrl(RESTAPIHelper.paymentRedirectUrl);
        }

        [Given(@"I wait until Next button is displayed")]
        public void GivenIWaitUntilNextButtonIsDisplayed()
        {
            //var nextButton = chromeDriver.FindElement(By.XPath(""));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[span(contains(text(), 'Next'))]")));
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
                chromeDriver.FindElementByXPath("//button[span(contains(text(), 'Next'))]").Click();
            }
            catch(Exception e)
            {
                System.Threading.Thread.Sleep(4000);
            }
        }

        [Then(@"I select the bank")]
        public void ThenISelectTheBank()
        {
            System.Threading.Thread.Sleep(5000);
            SelectElement oSelect = new SelectElement(chromeDriver.FindElement(By.Id("epsIssuerSelect")));
            oSelect.SelectByText("Bank Austria");
        }

        [Then(@"I click on Continue button")]
        public void ThenIClickOnContinueButton()
        {
            chromeDriver.FindElementById("mainSubmit").Click();
        }

        [Then(@"I add random values to the two input boxes")]
        public void ThenIAddRandomValuesToTheTwoInputBoxes()
        {

            chromeDriver.FindElementById("gebForm:verf_ID").SendKeys("test");

            chromeDriver.FindElementById("gebForm:pin_ID").SendKeys("test");

             }

        [Then(@"I click on the login button")]
        public void ThenIClickOnTheLoginButton()
        {
            chromeDriver.FindElementById("gebForm:LoginCommandButton").Click();
        }

        [Then(@"I verify the failure message")]
        public void ThenIVerifyTheFailureMessage()
        {
            System.Threading.Thread.Sleep(4000);

            chromeDriver.FindElementByXPath("//span[contains(text(), 'PIN falsch')]");
             
            
        }

        [Then(@"I click on Cancel button")]
        public void ThenIClickOnCancelButton()
        {
            chromeDriver.FindElementByXPath("//a[span[span[contains(@class, 'logout')]]]").Click();
        }

        [Then(@"I take the scrrenshot")]
        public void ThenITakeTheScrrenshot()
        {

            System.Threading.Thread.Sleep(4000);
            Screenshot ss = ((ITakesScreenshot)chromeDriver).GetScreenshot();
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
            chromeDriver.Close();
        }
        public void Dispose()
        {
            if (chromeDriver!=null)

            {
                chromeDriver.Dispose();
                chromeDriver=null;
            }
        }

    }
}
