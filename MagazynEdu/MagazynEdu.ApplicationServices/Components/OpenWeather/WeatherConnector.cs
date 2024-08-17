using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.Components.OpenWeather
{
    public class WeatherConnector : IWeatherConnector
    {
        public readonly RestClient restClient;
        private readonly string baseUrl = "http://api.openweathermap.org/";
        private readonly string apiKey = "04c845fb436baca08d33ad59d53159eb";

        public WeatherConnector()
        {
            this.restClient = new RestClient(baseUrl);
        }

        public async Task<Weather> Fetch(string city)
        {
            var request = new RestRequest("data/2.5/weather", Method.GET);
            request.AddParameter("appid", this.apiKey);
            request.AddParameter("q", city);
            var queryResult = await restClient.ExecuteAsync(request);
            var weather = JsonConvert.DeserializeObject<Weather>(queryResult.Content);
            return weather;
        }
    }
}
