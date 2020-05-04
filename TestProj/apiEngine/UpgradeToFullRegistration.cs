using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.apiEngine
{
    public class UpgradeToFullRegistration
    {
        
        public JObject jObjectbody = new JObject();
        public UpgradeToFullRegistration(string firstName, string lastName, bool isMale, string countryCode, string city, string zip, string street,
                                          int phonePrefix,  string phoneNumber, string securityQuestionTag, string securityAnswer) {

            jObjectbody.Add("firstName", firstName);
            jObjectbody.Add("lastName", lastName);
            jObjectbody.Add("isMale",Convert.ToBoolean(isMale));
            jObjectbody.Add("countryCode", countryCode);
            jObjectbody.Add("city", city);
            jObjectbody.Add("zip", zip );
            jObjectbody.Add("street", street );
            jObjectbody.Add("phonePrefix", phonePrefix );
            jObjectbody.Add("phoneNumber", phoneNumber );
            jObjectbody.Add("securityQuestionTag",  securityQuestionTag);
            jObjectbody.Add("securityAnswer",  securityAnswer); 
            }
    }
}
