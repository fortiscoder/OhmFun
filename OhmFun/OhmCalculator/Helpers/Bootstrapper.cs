using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace OhmCalculator
{
    /// <summary>
    /// Class for registering dependencies
    /// </summary>
    internal static class Bootstrapper
    {
        internal static IServiceProvider GetServiceProvider(IServiceCollection services)
        {
            // For a more complex application I would add SeriLog and Microsoft.Extension.Logging
            // services.AddLogging(.....) and add SeriLog


            // Register dependencies
            services.AddTransient<ICalculateOhmValues, CalculateOhmValuesImpl>();
            return services.BuildServiceProvider();
        }
    }
}
