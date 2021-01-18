using Contacts.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Application.Models
{
    public class ContactVWM
    {
        public long Id { get; set; }

        public EnumTypePerson Type { get; set; }

        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public EnumGender? Gender { get; set; }

        public string Cpf { get; set; }



        public string CompanyName { get; set; }

        public string TradeName { get; set; }

        public string Cnpj { get; set; }


        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string NameExibition { get; set; }

        public string DocumentExibition { get; set; }
    }
}
