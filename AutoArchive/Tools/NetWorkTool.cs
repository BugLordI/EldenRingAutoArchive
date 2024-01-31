using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tools
{
    public class NetWorkTool
    {
        public static async void CrawlInformation(String url)
        {
            try
            {
                string content = await GetWebPageContent(url);
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static async Task<string> GetWebPageContent(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                else
                {
                    throw new Exception($"Failed to retrieve web page. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
