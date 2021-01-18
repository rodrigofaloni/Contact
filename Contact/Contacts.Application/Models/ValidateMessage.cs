using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Contacts.Application.Models
{
    /// <summary>
    /// Class that implements the validate message.
    /// </summary>
    public class ValidateMessage
    {
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public int HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is error.
        /// </summary>
        public bool IsError { get; set; }
    }
}
