using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Rollin__Along.Data_classes
{
    public partial class Login
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        public FrmLogin Prijava
        {
            get => default(FrmLogin);
            set
            {
            }
        }
    }
}