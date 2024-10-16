using Microsoft.Extensions.DependencyInjection;
using Vives.Net.Http.Handlers;

namespace VivesBlog.Sdk.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services, string apiUrl)
        {
            services.AddScoped<AuthorizationHandler>();

            services.AddHttpClient("VivesBlogApi", httpClient =>
            {
                httpClient.BaseAddress = new Uri(apiUrl);
            }).AddHttpMessageHandler<AuthorizationHandler>();

            services.AddScoped<ArticleSdk>();
            services.AddScoped<IdentitySdk>();
            services.AddScoped<PersonSdk>();

            return services;
        }
    }
}
