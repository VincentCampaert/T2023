using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.Data.Interfaces;
using WebDev.Data.Repositories;

namespace WebDev.Data.Configuration
{
    public static class Configuration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
        }
    }
}
