using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Application.Contracts.Providers;
using WebDev.Application.Providers;

namespace WebDev.Application.Configuration
{
    public static class Configuration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDashboardProvider, DashboardProvider>();
            services.AddScoped<IGameProvider, GameProvider>();
            services.AddScoped<IPersonProvider, PersonProvider>();
            services.AddScoped<IUserProvider, UserProvider>();
        }
    }
}
