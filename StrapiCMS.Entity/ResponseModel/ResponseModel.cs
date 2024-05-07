using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StrapiCMS.Entity.ResponseModel
{
    public partial class Response
    {
        [JsonPropertyName("data")]
        public object? Data { get; set; }

        [JsonPropertyName("error")]
        public Error? Error { get; set; }
    }

    public partial class Error
    {
        [JsonPropertyName("status")]
        public long Status { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
