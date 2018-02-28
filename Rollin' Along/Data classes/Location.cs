using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Rollin__Along.Data_classes
{
    public partial class Location
    {
        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }
        [JsonProperty(PropertyName = "location")]
        public string LocationG { get; set; }
        [JsonProperty(PropertyName = "locationid")]
        public int Locationid { get; set; }
        [JsonProperty(PropertyName = "bicycle")]
        public Bicycle Bicycle { get; set; }
    }
}