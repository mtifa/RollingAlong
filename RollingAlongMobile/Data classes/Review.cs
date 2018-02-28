﻿using System;
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
    public class Review
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "stars")]
        public int Stars { get; set; }
        [JsonProperty(PropertyName = "reviewsid")]
        public int Reviewsid { get; set; }
    }
}