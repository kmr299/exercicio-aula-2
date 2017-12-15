using System.Data.Entity;
using Contatos.Data;

namespace Contatos.Entity
{
    public class ContatosContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
    }
}
