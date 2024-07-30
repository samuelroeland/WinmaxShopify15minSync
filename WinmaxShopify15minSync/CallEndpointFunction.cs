using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WinmaxShopify15minSync
{
    public class CallEndpointFunction
    {
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("CallEndpointFunction")]
        public static async Task Run([TimerTrigger("0 */15 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Shopify Winmax Timer trigger function executed at: {DateTime.Now}");
            Console.WriteLine("Shopify winmax timer trigger function started.");
            try
            {
                var response = await httpClient.GetAsync("https://rew03i8d.a2hosted.com/public/apply-mapping");
                response.EnsureSuccessStatusCode();

                log.LogInformation("Endpoint called successfully.");
                Console.WriteLine("Endpoint called successfully.");
            }
            catch (Exception ex)
            {
                log.LogError($"An error occurred: {ex.Message}");
            }
        }

    }
}
