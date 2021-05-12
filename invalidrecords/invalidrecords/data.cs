using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace invalidrecords
{
    
    public class data
    {
        public string name { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string id { get; set; }
    }
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
}
