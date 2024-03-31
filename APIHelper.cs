using System.Net.Http;

namespace SunInfo
{
    // Set up information for the API calls
    // Allows us to make api calls on the internet
    public static class APIHelper
    {
        //static ensures singleton pattern, open once per application
        public static HttpClient ApiClient { get; set; }  

        public static void IntializeClient()
        {
            //Set up ApiClient
            ApiClient = new HttpClient();

            //You can leave the following out if you want to consume multiple apis
            //ApiClient.BaseAddress = new Uri("https://api.sunrise-sunset.org/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();

            //we want to process json api replies
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
