using Microsoft.OpenApi.Models;

namespace VivesBlog.Api.Installers
{
    public static class OpenApiInstaller
    {
        public static void InstallOpenAPi(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var securityDefinition = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization head using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };

                options.AddSecurityDefinition("Bearer", securityDefinition);

                var securityRequirementScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        securityRequirementScheme, new string[] { }
                    }
                };
                options.AddSecurityRequirement(securityRequirement);
            });
        }
    }
}
