using Microsoft.Extensions.DependencyInjection;
using Net.Chdk.Detectors.Software.Binary;
using Net.Chdk.Detectors.Software.Product;

namespace Net.Chdk.Detectors.Software.Fhp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFhpSoftwareDetector(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ProductBinarySoftwareDetector, FhpSoftwareDetector>();
        }

        public static IServiceCollection AddFhpProductDetector(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ProductDetector, FhpProductDetector>();
        }
    }
}
