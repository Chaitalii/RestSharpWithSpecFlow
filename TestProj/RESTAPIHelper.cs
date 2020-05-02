using Gherkin;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestProj.Steps;

namespace TestProj
{
    class RESTAPIHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static IRestResponse apiResponse;
        public static String baseUrl = "https://www.gametwist.com/nrgs/en/api";
        public static string Token;
       

        public static RestClient SetUrl(string endPoint)
        {
            var url = baseUrl + endPoint;
            return client = new RestClient(url);

        }

        public static RestRequest CreateLoginRequest(string nickname, string password, Boolean autologin)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("nickname", nickname);
            restRequest.AddParameter("password", password);
            restRequest.AddParameter("autologin", autologin);
            return restRequest;
        }


        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }

        public static RestRequest CreatePostConsentRequest(string consentType, string accepted)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Token);
            restRequest.AddQueryParameter("consentType", consentType);
            restRequest.AddQueryParameter("accepted", accepted);

            return restRequest;
        }
        public static void ExtractToken(IRestResponse apiResponse)
        {
            Token = apiResponse.Headers.ToList()
                                .Find(x => x.Name == "x-nrgs-auth-token-jwt")
                                .Value.ToString();

        }
        public static RestRequest CreateGetConsentRequest(string consentType)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", "Bearer " + Token);
            restRequest.AddQueryParameter("consentType", consentType);
            return restRequest;
        }

        public static string GetValueFromDictionary(string key)
        {
            var deserialise = new JsonDeserializer();
            var output = deserialise.Deserialize<Dictionary<string, string>>(apiResponse);
            var res = output[key];
            return res;
           
        }



       /* public static void storeValuesinDictionary(string consentType, string value)
        {
            
            VerifyConsentSteps.consentTypes.Add(consentType, value);
            
        } */
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
            }
            return value;
        }
    }
}
