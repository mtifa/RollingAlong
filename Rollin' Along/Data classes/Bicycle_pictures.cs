using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollin__Along.Data_classes
{
    public partial class Bicycle_pictures
    {
        [JsonProperty(PropertyName = "pictureIds")]
        public List<string> PictureIds { get; set; }
        [JsonProperty(PropertyName = "bicycle")]
        public Bicycle Bicycle { get; set; }
    }
}
