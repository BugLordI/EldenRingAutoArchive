/*
 * Copyright (c) 2023-2026 BugZhang(BugLordl). All rights reserved.
 * Licensed under the Apache License(Version 2.0). See LICENSE file in the project root for full license information.
 * Version: v1.0.0
 * Author:  BugZhang(BugLordl)
 * Url:     https://github.com/BugLordI/EldenRingAutoArchive
 */
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tools
{
    public class NetWorkTool
    {
        public static async void CrawlInformation(String url, Action<String> action)
        {
            try
            {
                string content = await GetWebPageContent(url);
                action.Invoke(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async Task<string> GetWebPageContent(string url)
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
