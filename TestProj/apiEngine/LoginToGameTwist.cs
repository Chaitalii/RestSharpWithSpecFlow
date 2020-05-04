using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.apiEngine
{
   public  class LoginToGameTwist
    {
        public String nickname;
      public String password;
       public  JObject jObjectbody;
        public LoginToGameTwist(String nickname, String password)
        {
            this.nickname = nickname;
          this.password = password;

            jObjectbody = new JObject
            {
                { "nickname", nickname },
                { "password", password },
                { "autologin", true }
            };
        }
    }
}
