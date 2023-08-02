using Microsoft.Extensions.Configuration;
using System.IO;
namespace ApiReceitas
{
    public static class AppConfiguration
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();
    }
}
