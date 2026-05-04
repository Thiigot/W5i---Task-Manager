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

        var chamados = await _context.Chamados
            .Where(c => c.AtendimentoId == atendimentoId)
            .ToListAsync();

        ChamadosCriados = chamados.Count;

        ChamadosResolvidos = chamados
            .Count(c => c.Status == "Finalizado");

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
            atendimento.DataCheckOut = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        HttpContext.Session.Remove("AtendimentoId");

        return RedirectToPage("/Atendimento/Resumo", new { id = atendimento.Id });
    }
}