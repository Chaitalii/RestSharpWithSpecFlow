using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.apiEngine
{
  public  class ConsentAcceptance
    {
        public string consentType;
        public string accepted;
       
        public ConsentAcceptance(string consentType, string accepted)
        {
            this.consentType = consentType;
            this.accepted = accepted;
           
        }
    }
}
