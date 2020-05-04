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
        public ItemPurchase(string item, string paymentTypeId, string country, string landingUrl)
        {

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
