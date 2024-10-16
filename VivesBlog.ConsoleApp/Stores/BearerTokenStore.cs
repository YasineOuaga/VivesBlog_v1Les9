using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.Presentation.Authentication;

namespace VivesBlog.ConsoleApp.Stores
{
    public class BearerTokenStore: IBearerTokenStore
    {
        private static string Token { get; set; }
        public string GetToken()
        {
            return Token;
        }

        public void SetToken(string token)
        {
            Token = token;
        }
    }
}
