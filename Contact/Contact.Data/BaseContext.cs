using Contacts.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
          : base(options)
        {
        }

        public DbSet<Contact> Usuarios { get; set; }
    }
}
