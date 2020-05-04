using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.apiEngine
{
    class Route

    {

     private static readonly String LOGIN = "/login";
     private static readonly String CONSENT = "/consent/consent";
     private static readonly string FULL_REGISTRATION = "/player/upgradeToFullRegistrationgt";
     private static readonly string PURCHASE = "/purchase";
     private static readonly String VERSION = "-v1";
    
    
    public static String login()
        {
            return LOGIN + VERSION ;
        }

        public static String consent()
        {
            return CONSENT + VERSION;
        }

        public static String fullRegistration()
        {
            return FULL_REGISTRATION + VERSION;
        }

        public static String purchase()
        {
            return PURCHASE + VERSION ;
        }
    }
}
