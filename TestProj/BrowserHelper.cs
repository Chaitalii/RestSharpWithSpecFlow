using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj
{
    class BrowserHelper
    {

        private ChromeDriver chromeDriver;
        
        public BrowserHelper()
        {
            chromeDriver = new ChromeDriver();
        }

        public void launchBrowser(string url)
        {
            chromeDriver.Navigate().GoToUrl(url);
        }
    }
}
