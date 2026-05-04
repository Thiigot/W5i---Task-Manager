using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W5i___Controle_de_Atendimentos.Entities;

public class ResumoModel : PageModel
{
    private readonly AppDbContext _context;

    public ResumoModel(AppDbContext context)
    {
        _context = context;
    }

    public Atendimento Atendimento { get; set; } = new();

    public int ChamadosCriados { get; set; }
    public int ChamadosResolvidos { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        int? atendimentoId = id ?? HttpContext.Session.GetInt32("AtendimentoId");

        if (atendimentoId == null)
            return RedirectToPage("/Index");

        Atendimento = await _context.Atendimentos
            .FirstOrDefaultAsync(a => a.Id == atendimentoId);

        if (Atendimento == null)
            return NotFound();

        ChamadosCriados = await _context.Chamados
            .CountAsync(c => c.AtendimentoCriacaoId == atendimentoId);

        ChamadosResolvidos = await _context.Chamados
            .CountAsync(c => c.AtendimentoResolucaoId == atendimentoId);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var id = HttpContext.Session.GetInt32("AtendimentoId");

        if (id == null)
            return RedirectToPage("/Index");

        var atendimento = await _context.Atendimentos
            .FirstOrDefaultAsync(a => a.Id == id);

        if (atendimento == null)
            return NotFound();

        if (atendimento.DataCheckOut == null)
        {
            atendimento.TotalChamadosCriados = await _context.Chamados
                .CountAsync(c => c.AtendimentoCriacaoId == id);

            atendimento.TotalChamadosResolvidos = await _context.Chamados
                .CountAsync(c => c.AtendimentoResolucaoId == id);

            atendimento.DataCheckOut = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        HttpContext.Session.Remove("AtendimentoId");

        return RedirectToPage("/Atendimento/Resumo", new { id = atendimento.Id });
    }
}