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
    class EquipmentWithRent
    {
        [JsonProperty(PropertyName = "equipmentid")]
        public int EquipmentWithRentId { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "price_per_day")]
        public double PricePerDay { get; set; }
        [JsonProperty(PropertyName = "price_per_hour")]
        public double PricePerHour { get; set; }
        [JsonProperty(PropertyName = "state")]
        public int State { get; set; }
        [JsonProperty(PropertyName = "category")]
        public Category Category { get; set; }
    }
}