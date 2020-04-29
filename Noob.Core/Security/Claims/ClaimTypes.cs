using System;
using System.Collections.Generic;
using System.Text;

namespace Noob.Security.Claims
{
    //TODO: Instead of directly using static properties, can we just create an ClaimOptions and pass these values as defaults?
    /// <summary>
    /// Used to get specific claim type names.
    /// </summary>
    public static class ClaimTypes
    {

        /// <summary>
        /// Default: "client_id".
        /// </summary>
        public static string ClientId { get; set; } = "client_id";
    }
}
