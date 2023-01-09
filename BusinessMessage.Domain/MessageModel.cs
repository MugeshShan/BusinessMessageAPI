using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessMessage.Domain
{
    public class MessageModel
    {
        [JsonPropertyName("clientToken")]
        public string ClientToken { get; set; }

        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }
}
