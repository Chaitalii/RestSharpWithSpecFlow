using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.apiEngine
{

   
   public  class CurrentAcceptanceStatus
    {
        public string consentType;
        public CurrentAcceptanceStatus(string consentType)
        {
            this.consentType = consentType;

        }
    }
}
