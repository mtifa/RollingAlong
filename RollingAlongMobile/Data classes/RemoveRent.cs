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
    class RemoveRent
    {
        [JsonProperty(PropertyName = "rentid")]
        public int RentID { get; set; }
        [JsonProperty(PropertyName = "issuedesc")]
        public string IssueDesc { get; set; }
    }
}