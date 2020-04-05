using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Noob.D2CMSApi.Models.Requests
{
    /// <summary>
    /// Class LoginRequest.
    /// Implements the <see cref="Noob.D2CMSApi.Models.Request.RequestBase" />
    /// </summary>
    /// <seealso cref="Noob.D2CMSApi.Models.Request.RequestBase" />
    [Serializable]
    public class LoginRequest:RequestBase
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
