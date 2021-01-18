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
    /// <summary>
    /// Class that implements the contact vwm.
    /// </summary>
    public class ContactVWM
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public EnumTypePerson Type { get; set; }

        #region Natural person properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public EnumGender? Gender { get; set; }

        /// <summary>
        /// Gets or sets the CPF.
        /// </summary>
        public string Cpf { get; set; }

        #endregion

        #region Legal person properties
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the trade.
        /// </summary>
        public string TradeName { get; set; }

        /// <summary>
        /// Gets or sets the CNPJ.
        /// </summary>
        public string Cnpj { get; set; }
        #endregion

        #region Address
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        public string AddressLine2 { get; set; }
        #endregion

        #region Properties for lists
        /// <summary>
        /// Gets or sets the name exibition.
        /// </summary>
        public string NameExibition { get; set; }

        /// <summary>
        /// Gets or sets the document exibition.
        /// </summary>
        public string DocumentExibition { get; set; }
        #endregion
    }
}
