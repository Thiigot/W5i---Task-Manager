using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using W5i___Controle_de_Atendimentos.Entities;

public class CreateAtendimentoModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateAtendimentoModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Atendimento Atendimento { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        Atendimento.DataCheckIn = DateTime.UtcNow;

        _context.Atendimentos.Add(Atendimento);
        await _context.SaveChangesAsync();

        HttpContext.Session.SetInt32("AtendimentoId", Atendimento.Id);

        return RedirectToPage("/Chamados/List");
    }
}