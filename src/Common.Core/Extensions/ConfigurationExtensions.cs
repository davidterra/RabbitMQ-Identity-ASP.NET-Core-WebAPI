using Microsoft.Extensions.Configuration;

namespace Common.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetMessageQueueConnection(this IConfiguration configuration, string name) 
            => configuration?.GetSection("MessageQueueConnection")?[name];
    }
}
