using MemesFinderTextProcessor.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: FunctionsStartup(typeof(MemesFinderTextProcessor.Startup))]
namespace MemesFinderTextProcessor
{
    public class Startup : FunctionsStartup
    {
        private IConfigurationRoot _functionConfig;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            _functionConfig = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddServiceBusKeywordClient(_functionConfig);
            builder.Services.AddTextAnalyticsClient(_functionConfig);

            builder.Services
                .AddLogging()
                .AddScoped<ILogger>(provider => provider.GetRequiredService<ILogger<MemesFinderTextProcessor>>());
        }
    }
}

