using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noob.D2CMSApi.Models.Requests.System.Query
{
    /// <summary>
    /// Class PostQuery.
    /// Implements the <see cref="Noob.D2CMSApi.Models.PaggingBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.PaggingBase" />
    public class PostQuery : PaggingBase
    {
        /// <summary>
        /// Gets or sets the name of the post.
        /// </summary>
        /// <value>The name of the post.</value>
        [JsonProperty("post_name")]
        public string PostName { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public byte Status { get; set; }
    }
}
