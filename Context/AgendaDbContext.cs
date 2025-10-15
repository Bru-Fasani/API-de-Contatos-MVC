using Microsoft.EntityFrameworkCore;

namespace API_MVC.Context
{
    public class AgendaDbContext : DbContext
    {
        public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options) { }
        public DbSet<Models.Contato> Contatos { get; set; }
    }
}
