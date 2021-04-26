using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.Client
{
    /// <summary>
    /// ApiHelper - simple client for connecting with external API
    /// </summary>
    public static class ApiHelper
    {
        public static HttpClient APIClient { get; set; }

        /// <summary>
        /// Initializes API client
        /// </summary>
        public static void InitializeClient()
        {
            APIClient = new HttpClient();
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
