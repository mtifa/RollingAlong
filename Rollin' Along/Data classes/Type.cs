using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Rollin__Along.Data_classes
{
    public partial class Type
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "usertypeid")]
        public int UserTypeId { get; set; }
    }
}