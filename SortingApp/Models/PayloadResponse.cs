using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SortingApp.Models
{
    internal class PayloadResponse<T>
    {
        [JsonProperty("payload")]
        public List<T> Payload { get; set; }
    }

}