using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.Context
{


    public class BrowserContext
    {

        public ChromeDriver driver;
        
        public BrowserContext()
        {
            driver = new ChromeDriver();
            
        }

    }
}
