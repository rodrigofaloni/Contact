using Contacts.Base.Entity;

namespace Contacts.Domain.Entity
{
    /// <summary>
    /// Class that implements the legal person.
    /// </summary>
    public class LegalPerson : BaseEntity
    {
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
    }
}
