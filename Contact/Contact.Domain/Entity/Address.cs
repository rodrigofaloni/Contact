using Contacts.Base.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Entity
{
    /// <summary>
    /// Class that implements the address.
    /// </summary>
    public class Address : BaseEntity
    {
       public string ZipCode { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
    }
}
