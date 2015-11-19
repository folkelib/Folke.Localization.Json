using System;
using Folke.Localization.Json;
using Microsoft.Extensions.Localization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class JsonLocalizationServiceCollectionExtensions
    {
        public static IServiceCollection AddJsonLocalization(this IServiceCollection services, Action<JsonStringLocalizerOptions> options)
        {
            if (options != null)
            {
                services.Configure(options);
            }
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.AddSingleton(typeof(IStringLocalizer<>), typeof(JsonStringLocalizer<>));
            return services;
        }
    }
}
