using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dependencies
{
    public static class RegisterDependencies
    {
        public static void ConfigureBLLServices(this IServiceCollection services)
        {
            services.AddScoped<TextMaterialService>();
            services.AddScoped<TextMaterialCategoryService>();
            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
        }
    }
}
