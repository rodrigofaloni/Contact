using System;

namespace Contacts.Application.Models
{
    public class ErrorVWM
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
