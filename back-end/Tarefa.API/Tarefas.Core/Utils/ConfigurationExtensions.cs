using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace Tarefas.Core.Utils
{
    public static class ConfigurationExtensions
    {
        public static string GetMessageQueueConnection(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("MessageQueueConnection")?[name];
        }
    }
    public static class ConvertObject
    {
        public static byte[] GetSerealisationBytes(this Object objeto)
        {
            String jsonified = JsonConvert.SerializeObject(objeto);
            return Encoding.UTF8.GetBytes(jsonified);
        }
        public static T GetSerealisationBytes<T>(this byte[] bytes)
        {
            String jsonified = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(jsonified);
        }
        
    }
}