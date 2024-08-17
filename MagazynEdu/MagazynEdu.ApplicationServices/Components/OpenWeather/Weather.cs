using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynEdu.ApplicationServices.Components.OpenWeather
{
    public class Weather
    {
        public string Name { get; set; }

        [JsonProperty("main")]
        public MainData Main { get; set; }
    }
}
