using Newtonsoft.Json;

namespace RollingAlongMobile.Data_classes
{
    public class Bicycle
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
        [JsonProperty(PropertyName = "bicycleid")]
        public int Bicycleid { get; set; }
        [JsonProperty(PropertyName = "category")]
        public Category Category { get; set; }
    }
}