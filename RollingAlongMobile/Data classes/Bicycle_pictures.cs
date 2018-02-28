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
    class Bicycle_pictures
    {
        [JsonProperty(PropertyName = "pictureIds")]
        public List<string> PictureIds { get; set; }
        [JsonProperty(PropertyName = "bicycle")]
        public Bicycle Bicycle { get; set; }
    }
}