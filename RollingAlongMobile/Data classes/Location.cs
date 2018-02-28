using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace RollingAlongMobile.Data_classes
{
    public class Location
    {
        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }
        [JsonProperty(PropertyName = "location")]
        public string LocationG { get; set; }

        [JsonProperty(PropertyName = "bicycle")]
        public Bicycle Bicycle { get; set; }
    }
}