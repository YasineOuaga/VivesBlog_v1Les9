using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VivesBlog.Core;

namespace VivesBlog.Api.Installers
{
    public static class EntityFrameworkInstaller
    {
        public static void InstallEntityFramework(this IServiceCollection services)
        {
            services.AddDbContext<VivesBlogDbContext>(options =>
                {
                    options.UseInMemoryDatabase(nameof(VivesBlogDbContext));
                }).AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<VivesBlogDbContext>();
        }
    }
}
