using Contacts.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    /// <summary>
    /// Classe that implements the base context.
    /// </summary>
    public class BaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public BaseContext(DbContextOptions<BaseContext> options)
          : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        public DbSet<Contact> Contacts { get; set; }
    }
}
