using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Requests
{
    /// <summary>
    /// Class PaggingRequest.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Requests.RequestBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Requests.RequestBase" />
    public class PaggingRequest : RequestBase
    {
        /// <summary>
        ///page
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }
        /// <summary>
        ///page_size
        /// </summary>
        [JsonProperty("page_size")]
        public int PageSize { get; set; }
        /// <summary>
        ///order_column_name
        /// </summary>
        [JsonProperty("order_column_name")]
        public string OrderColumnName { get; set; }
        /// <summary>
        ///order_type
        /// </summary>
        [JsonProperty("order_type")]
        public string OrderType { get; set; }
    }
}
