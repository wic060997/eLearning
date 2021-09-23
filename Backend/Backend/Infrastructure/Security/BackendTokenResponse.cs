using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Security
{
    public class BackendTokenResponse
    {
        [JsonProperty("Result")]
        public BackendTokenResult Result { get; set; }
    }
}
