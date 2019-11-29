using Microsoft.Extensions.DependencyInjection;
using SharedKernel;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DET.Web.Configurations
{
    public static class LoggerServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
