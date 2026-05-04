using Microsoft.EntityFrameworkCore;
using W5i___Controle_de_Atendimentos.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Setor> Setores { get; set; }
    public DbSet<Prioridade> Prioridades { get; set; }
    public DbSet<Chamado> Chamados { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Setor>().ToTable("Setores");
        modelBuilder.Entity<Prioridade>().ToTable("Prioridades");
        modelBuilder.Entity<Chamado>().ToTable("Chamados");
        modelBuilder.Entity<Atendimento>().ToTable("Atendimentos");

        modelBuilder.Entity<Chamado>()
            .HasOne(c => c.AtendimentoCriacao)
            .WithMany(a => a.ChamadosCriados)
            .HasForeignKey(c => c.AtendimentoCriacaoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Chamado>()
            .HasOne(c => c.AtendimentoResolucao)
            .WithMany(a => a.ChamadosResolvidos)
            .HasForeignKey(c => c.AtendimentoResolucaoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}