using Azure.Identity;
using MemesFinderTextProcessor.AzureClients;
using MemesFinderTextProcessor.Interfaces.AzureClients;
using MemesFinderTextProcessor.Options;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MemesFinderTextProcessor.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddServiceBusKeywordClient(this IServiceCollection services, IConfiguration configuration)
		{
            services.Configure<ServiceBusOptions>(configuration.GetSection("ServiceBusOptions"));

            services.AddAzureClients(clientBuilder =>
            {
                var provider = services.BuildServiceProvider();

                clientBuilder.UseCredential(new DefaultAzureCredential());
                clientBuilder.AddServiceBusClientWithNamespace(provider.GetRequiredService<IOptions<ServiceBusOptions>>().Value.FullyQualifiedNamespace);
            });

            services.AddTransient<IServiceBusClient, ServiceBusKeywordMessagesClient>();
            return services;
		}
	}
}

