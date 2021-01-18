using Contacts.Base.Entity;
using Contacts.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Domain.Entity
{
    /// <summary>
    /// Class that implements the legal person.
    /// </summary>
    public class LegalPerson : BaseEntity
    {



        public string CompanyName { get; set; }

        public string TradeName { get; set; }

        public string Cnpj { get; set; }
    }
}
