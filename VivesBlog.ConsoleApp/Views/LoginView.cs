using Vives.Presentation.Authentication;
using VivesBlog.Dtos.Requests;
using VivesBlog.Sdk;

namespace VivesBlog.ConsoleApp.Views
{
    public class LoginView(IdentitySdk identitySdk, IBearerTokenStore tokenStore)
    {
        private readonly IdentitySdk _identitySdk = identitySdk;
        private readonly IBearerTokenStore _tokenStore = tokenStore;

        public async Task Show()
        {
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();

            var request = new SignInRequest { Username = username, Password = password };
            var result = await _identitySdk.SignIn(request);
            var jwtToken = result.Token;
            //Save the token in the IBearerTokenStore
            _tokenStore.SetToken(jwtToken);
        }
    }
}
