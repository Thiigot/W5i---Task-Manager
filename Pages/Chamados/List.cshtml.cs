using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W5i___Controle_de_Atendimentos.Entities;

public class ListModel : PageModel
{
    private readonly AppDbContext _context;

    public ListModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Chamado> Chamados { get; set; }

    public void OnGet()
    {
        Chamados = _context.Chamados
            .Include(c => c.Prioridade)
            .Include(c => c.Setor) 
            .OrderBy(c => c.Status != "Aberto") 
            .ThenBy(c => c.Prioridade.TempoEstimadoHoras)
            .ThenBy(c => c.DataCriacao)
            .ToList();
    }
}