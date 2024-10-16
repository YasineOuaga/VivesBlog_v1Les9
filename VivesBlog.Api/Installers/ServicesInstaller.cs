using VivesBlog.Services;

namespace VivesBlog.Api.Installers
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IServiceCollection services)
        {
            services.AddScoped<ArticleService>();
            services.AddScoped<IdentityService>();
            services.AddScoped<PersonService>();
        }
    }
}
