using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppPinger.Infrastructure.Interface;
using WebAppPinger.Models;


namespace WebAppPinger.Infrastructure
{
    public class ServiceRequester : IServiceRequester
    {
        public async Task FireAndForget(EndpointModel model)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(model.Url)
            };

            using (var client = new HttpClient())
            {
                await client.SendAsync(message);
            }
        }
    }
}