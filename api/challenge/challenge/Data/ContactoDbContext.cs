using Microsoft.EntityFrameworkCore;
using challenge.Models.Domain;

namespace challenge.Data
{
    public class ContactoDbContext : DbContext
    {
        public ContactoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contacto> Contactos { get; set; }
    }
}
