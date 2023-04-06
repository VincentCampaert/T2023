using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Domain.Interfaces;
using WebDev.Domain.Services;

namespace WebDev.Domain.Configuration
{
    public static class Configuration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
        }
    }
}
