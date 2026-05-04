using Microsoft.AspNetCore.Mvc;
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

    public List<Chamado> Chamados { get; set; } = new List<Chamado>();

    public void OnGet()
    {
        Chamados = _context.Chamados
            .Include(c => c.Prioridade)
            .Include(c => c.Setor)
            .OrderBy(c => c.Status != "Aberto")
            .ThenBy(c => c.Prioridade.TempoEstimadoHoras)
            .ThenBy(c => c.DataCriacao)
            .ToList() ?? new List<Chamado>();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var atendimentoId = HttpContext.Session.GetInt32("AtendimentoId");

        if (atendimentoId == null)
            return RedirectToPage("/Index");

        var atendimento = await _context.Atendimentos
            .FirstOrDefaultAsync(a => a.Id == atendimentoId);

        if (atendimento == null)
            return NotFound();

        if (atendimento.DataCheckOut == null)
        {
            var totalCriados = await _context.Chamados
                .CountAsync(c => c.AtendimentoCriacaoId == atendimentoId);

            var totalResolvidos = await _context.Chamados
                .CountAsync(c => c.AtendimentoResolucaoId == atendimentoId);

            atendimento.TotalChamadosCriados = totalCriados;
            atendimento.TotalChamadosResolvidos = totalResolvidos;

            atendimento.DataCheckOut = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        HttpContext.Session.Remove("AtendimentoId");

        return RedirectToPage("/Atendimento/Resumo", new { id = atendimento.Id });
    }
}