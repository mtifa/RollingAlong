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
    public class Equipment
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "state")]
        public int State { get; set; }
        [JsonProperty(PropertyName = "price_per_hour")]
        public double Price_per_hour { get; set; }
        [JsonProperty(PropertyName = "price_per_day")]
        public double Price_per_day { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "equipmentid")]
        public int Equipmentid { get; set; }
        [JsonProperty(PropertyName = "category")]
        public Category Category { get; set; }
    }
}