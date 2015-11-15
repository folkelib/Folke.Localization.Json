using Folke.Localization.Json;
using Microsoft.Framework.Localization;

namespace Microsoft.Framework.DependencyInjection
{
    public static class JsonLocalizationServiceCollectionExtensions
    {
        public static IServiceCollection AddJsonLocalization(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.AddSingleton(typeof(IStringLocalizer<>), typeof(JsonStringLocalizer<>));
            return services;
        }
    }
}
