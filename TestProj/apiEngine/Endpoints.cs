using Gherkin;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using TestProj.apiEngine;
using TestProj.Steps;


namespace TestProj
{
    public class EndPoints
    {

        private readonly static String BASE_URL = "https://www.gametwist.com/nrgs/en/api";
        private readonly static String PURCHASE_BASE_URL = "https://payments-api-v1-at.greentube.com/gametwist.widgets.web.site/en/api";
        private  RestRequest restRequest;
        private RestClient client ;
        private static  string auth_token;
        private string url;
        public  IRestResponse response;



        public EndPoints()
        {
            restRequest = new RestRequest();
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
        } 


        public  IRestResponse loginToGameTwist(LoginToGameTwist login)
        {
            url = BASE_URL + Route.login();
            client = new RestClient(url);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter("application/json", login.jObjectbody, ParameterType.RequestBody);
             response = client.Execute(restRequest);
            auth_token = response.Headers.ToList()
                                .Find(x => x.Name == "x-nrgs-auth-token-jwt")
                                .Value.ToString();
            
            return response;
        }

        public  IRestResponse postConsent(ConsentAcceptance consent)
        {
            url = BASE_URL + Route.consent();
            client = new RestClient(url);
            restRequest = new RestRequest(Method.POST);
             restRequest.AddHeader("Authorization", "Bearer " + auth_token);
             restRequest.AddQueryParameter("consentType", consent.consentType);
            restRequest.AddQueryParameter("accepted", consent.accepted);
             response = client.Execute(restRequest);
            return response;
        }

        public  IRestResponse getConsent(CurrentAcceptanceStatus acceptanceStatus)
        {
            url = BASE_URL + Route.consent();
            client = new RestClient(url);
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Authorization", "Bearer " + auth_token);
            restRequest.AddQueryParameter("consentType", acceptanceStatus.consentType);
             response = client.Execute(restRequest);
            return response;
        }

        public  IRestResponse upgradeToFullRegistrationGT(UpgradeToFullRegistration registration)
        {
            url = BASE_URL + Route.fullRegistration();
            client = new RestClient(url);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Authorization", "Bearer " + auth_token);
            restRequest.AddParameter("application/json", registration.jObjectbody, ParameterType.RequestBody);
            response = client.Execute(restRequest);
            return response;
        }

        public   IRestResponse purchase(ItemPurchase purchase)
        {
            var url = PURCHASE_BASE_URL + Route.purchase();
            RestClient client = new RestClient(url);
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Authorization", "Bearer " + auth_token);
            restRequest.AddParameter("application/json", purchase.jObjectbody, ParameterType.RequestBody);
             response = client.Execute(restRequest);
            return response;
        }
    }
}
