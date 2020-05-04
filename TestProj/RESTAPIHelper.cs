using Gherkin;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestProj.Steps;

namespace TestProj
{
    class RESTAPIHelper
    {
           

        public  string GetValueFromDictionary(IRestResponse response, string key)
        {
            var deserialise = new JsonDeserializer();
            var output = deserialise.Deserialize<Dictionary<string, string>>(response);
            var res = output[key];
            return res;
           
        }




        public static String GetValueFromDictionary(Dictionary<string, string> Content, string key)
        {
            String value=null;
            
              foreach (KeyValuePair<string, string> consent in Content)
                {
                    if (consent.Key == key)
                    {
                        value = consent.Value;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            
            return value;
        }
    }
}
