using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollin__Along.Data_classes
{
    public partial class Issue 
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "state")]
        public int State { get; set; }
        [JsonProperty(PropertyName = "date_created")]
        public string Date_created { get; set; }
        [JsonProperty(PropertyName = "date_resolved")]
        public string Date_resolved { get; set; }
        [JsonProperty(PropertyName = "issueid")]
        public int Issueid { get; set; }
        [JsonProperty(PropertyName = "rent")]
        public Rent Rent { get; set; }
    }
}
