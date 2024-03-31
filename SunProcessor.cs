using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SunInfo
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=35.045631&lng=-85.309677";
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel SunResult = await response.Content.ReadAsAsync<SunResultModel>();
                    return SunResult.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<SunModel> LoadSunInformation(double lat, double lon)
        {
            string url = "https://api.sunrise-sunset.org/json?lat=" + lat+ " + &lng="+ lon;
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    SunResultModel SunResult = await response.Content.ReadAsAsync<SunResultModel>();
                    return SunResult.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<SunModel> LoadSunInformation(double lat, double lon, String aDate)
        {
            string url = "https://api.sunrise-sunset.org/json?lat=" + lat + " + &lng=" + lon + "&date=" + aDate;
            //https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=2020-12-18
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {                    
                    SunResultModel SunResult = await response.Content.ReadAsAsync<SunResultModel>();
                    return SunResult.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
