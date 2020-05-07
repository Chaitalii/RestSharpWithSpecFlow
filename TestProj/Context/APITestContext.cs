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
        private EndPoints endPoints;

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

