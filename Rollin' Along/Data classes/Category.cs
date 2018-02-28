using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Newtonsoft.Json;

namespace Rollin__Along.Data_classes
{
    public partial class Category
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "categoryid")]
        public int Categoryid { get; set; }

        
    }
}