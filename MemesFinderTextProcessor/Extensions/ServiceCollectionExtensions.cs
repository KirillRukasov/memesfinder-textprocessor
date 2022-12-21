using Azure.AI.TextAnalytics;
using Azure.Identity;
using MemesFinderTextProcessor.Clients.AzureClients;
using MemesFinderTextProcessor.Interfaces.AzureClients;
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
            services.AddTransient<IServiceBusModelSender, ServiceBusModelSender>();
            return services;
		}

        public static IServiceCollection AddTextAnalyticsClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TextAnalyticsOptions>(configuration.GetSection("TextAnalyticsOptions"));

            services.AddAzureClients(clientBuilder =>
            {
                var provider = services.BuildServiceProvider();
                var textAnalyticsOptions = provider.GetRequiredService<IOptions<TextAnalyticsOptions>>().Value;

                clientBuilder
                    .AddTextAnalyticsClient(textAnalyticsOptions.Url)
                    .ConfigureOptions(options => options.DefaultLanguage = textAnalyticsOptions.Language);
            });

            services.AddTransient<ITextAnalyticsClient, KeyPhraseExtractor>();

            return services;
        }

    }
}

