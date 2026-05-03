using Microsoft.EntityFrameworkCore;
using W5i___Controle_de_Atendimentos.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Setor> Setores { get; set; }
    public DbSet<Prioridade> Prioridades { get; set; }
    public DbSet<Chamado> Chamados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Setor>().ToTable("Setores");
        modelBuilder.Entity<Prioridade>().ToTable("Prioridades");
        modelBuilder.Entity<Chamado>().ToTable("Chamados");
    }
}