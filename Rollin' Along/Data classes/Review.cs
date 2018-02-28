using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Rollin__Along.Data_classes
{
    public partial class Review
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "stars")]
        public int Stars { get; set; }
        [JsonProperty(PropertyName = "reviewsid")]
        public int Reviewsid { get; set; }

        public override string ToString()
        {
            return Reviewsid.ToString();
        }
    }
}