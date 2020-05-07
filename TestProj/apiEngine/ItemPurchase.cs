using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.apiEngine
{
   public  class ItemPurchase
    {
        public JObject jObjectbody;
        string item;
        string paymentTypeId;
        string country;
        string landingUrl;

        public ItemPurchase(string item, string paymentTypeId, string country, string landingUrl)
        {

            this.item = item;
            this.paymentTypeId = paymentTypeId;
            this.country = country;
            this.landingUrl = landingUrl;


            jObjectbody = new JObject
            {
                { "item", item },
                { "paymentTypeId", paymentTypeId },
                { "country", country },
                { "landingURL", landingUrl}
            };




        }
    }
}
