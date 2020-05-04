using OpenQA.Selenium.Chrome;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.Context
{
  public  class APITestContext
    {

        public ChromeDriver driver;
        private EndPoints endPoints;
       // private  String BASE_URL = "https://www.gametwist.com/nrgs/en/api";

        public APITestContext()
        {
            endPoints = new EndPoints();
        }

        public EndPoints getEndPoints()
        {
            return endPoints;
        }
    }



}

