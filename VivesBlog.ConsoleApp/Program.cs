using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vives.Presentation.Authentication;
using VivesBlog.ConsoleApp.Settings;
using VivesBlog.ConsoleApp.Stores;
using VivesBlog.ConsoleApp.Views;
using VivesBlog.Dtos.Requests;
using VivesBlog.Sdk;
using VivesBlog.Sdk.Extensions;

var configurationBuilder = new ConfigurationBuilder();
var services = new ServiceCollection();

configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var configuration = configurationBuilder.Build();

var apiSettings = new ApiSettings();
configuration.GetSection(nameof(ApiSettings)).Bind(apiSettings);
services.AddApi(apiSettings.BaseUrl);
services.AddScoped<IBearerTokenStore, BearerTokenStore>();

//Register Views
services.AddScoped<LoginView>();

var serviceProvider = services.BuildServiceProvider();

//Choose login or register
Console.WriteLine("Do you wish to \"login\" or \"register\"? Type the command:");
Console.Write("Command> ");
var command = Console.ReadLine();

var identitySdk = serviceProvider.GetRequiredService<IdentitySdk>();
var tokenStore = serviceProvider.GetRequiredService<IBearerTokenStore>();

var jwtToken = string.Empty;

switch (command)
{
    //login
    // - Get username
    // - Get password
    // - Execute Login
    // - Get bearer token
    // - Save bearer token
    case "login":
        var loginView = serviceProvider.GetRequiredService<LoginView>();
        await loginView.Show();
        break;
    //register
    // - Get username
    // - Get password
    // - Register user
    // - Get bearer token
    // - Save bearer token
    case "register":
        Console.WriteLine("Username: ");
        var registerUsername = Console.ReadLine();
        Console.WriteLine("Password: ");
        var registerPassword = Console.ReadLine();

        var registerRequest = new RegisterRequest() { Username = registerUsername, Password = registerPassword };
        var registerResult = await identitySdk.Register(registerRequest);
        jwtToken = registerResult.Token;
        //Save the token in the IBearerTokenStore
        tokenStore.SetToken(jwtToken);
        break;

    case "colorfun":
         var random = new Random();
        while (true)
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    var randomColorIndex = random.Next(16);
                    Console.ForegroundColor = (ConsoleColor)randomColorIndex;
                    var randomBackgroundIndex = random.Next(16);
                    Console.BackgroundColor = (ConsoleColor)randomBackgroundIndex;
                    Console.Write("@");
                    Console.ResetColor();
                }

                Console.Write(Environment.NewLine);
            }

            //var key = Console.Read();
            await Task.Delay(200);
        }

        Console.ReadLine();
        break;
    default:
        Console.WriteLine("Wrong command");
        break;
}

//Show People list
var personSdk = serviceProvider.GetRequiredService<PersonSdk>();
var people = await personSdk.Find();
foreach (var person in people)
{
    Console.WriteLine($"{person.FirstName} {person.LastName} ({person.NumberOfArticles})");
}





Console.WriteLine("Press any key to exit.");
Console.ReadLine();