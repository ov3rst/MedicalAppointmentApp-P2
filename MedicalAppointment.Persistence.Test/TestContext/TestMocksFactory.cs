using Microsoft.Extensions.Configuration;

namespace MedicalAppointment.Persistence.Test.TestContext
{
    public static class TestMocksFactory
    {
        /// <summary>
        /// Crea una instancia de IConfiguration vacía o personalizada.
        /// </summary>
        public static IConfiguration CreateConfiguration(Dictionary<string, string>? settings = null)
        {
            var configBuilder = new ConfigurationBuilder();

            if (settings is not null)
            {
                configBuilder.AddInMemoryCollection(settings!);
            }

            return configBuilder.Build();
        }
    }
}
