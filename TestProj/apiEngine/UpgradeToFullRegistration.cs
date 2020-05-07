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
        string firstName;
        string lastName;
        bool   isMale;
        string countryCode;
        string city;
        string zip;
        string street;
        int    phonePrefix;
        string phoneNumber;
        string securityQuestionTag;
        string securityAnswer;

        public JObject jObjectbody = new JObject();
        public UpgradeToFullRegistration(string firstName, string lastName, bool isMale, string countryCode, string city, string zip, string street,
                                          int phonePrefix,  string phoneNumber, string securityQuestionTag, string securityAnswer) {

            this.firstName = firstName;
            this.lastName = lastName;
            this.isMale = isMale;
            this.countryCode = countryCode;
            this.city = city;
            this.zip = zip;
            this.street = street;
            this.phonePrefix = phonePrefix;
            this.phoneNumber = phoneNumber;
            this.securityQuestionTag = securityQuestionTag;
            this.securityAnswer = securityAnswer;

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
