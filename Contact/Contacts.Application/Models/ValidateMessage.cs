using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Contacts.Application.Models
{
    public class ValidateMessage
    {
        public int HttpStatusCode { get; set; }

        public string Message { get; set; }

        public bool IsError { get; set; }
    }
}
