using System;

namespace Contacts.Application.Models
{
    /// <summary>
    /// Class that implements the error vwm.
    /// </summary>
    public class ErrorVWM
    {
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether [show request identifier].
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
