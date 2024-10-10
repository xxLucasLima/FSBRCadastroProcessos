using FSBRCadastroProcessos.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FSBRCadastroProcessos.API.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Cadastro> Cadastros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastro>().HasKey(c => c.Id);
        }
    }
}
