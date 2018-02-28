using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace Rollin__Along.Data_classes
{
    public partial class User
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "apikey")]
        public string ApiKey { get; set; }
        [JsonProperty(PropertyName = "userid")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "type")]
        public Type Type { get; set; }

        public override string ToString()
        {
            return Username + " - " + UserId;
        }
    }
}