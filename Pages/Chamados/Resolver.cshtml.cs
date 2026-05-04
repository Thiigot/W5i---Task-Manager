using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W5i___Controle_de_Atendimentos.Entities;

public class ResolverModel : PageModel
{
    private readonly AppDbContext _context;

    public ResolverModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public string Solucao { get; set; }

    public IActionResult OnGet(int id)
    {
        var chamado = _context.Chamados.FirstOrDefault(c => c.Id == id);

        if (chamado == null)
            return NotFound();

        Id = chamado.Id;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var chamado = _context.Chamados.FirstOrDefault(c => c.Id == Id);

        if (chamado == null)
            return NotFound();

        if (chamado.AtendimentoId == null)
        {
            ModelState.AddModelError("", "Chamado não foi iniciado.");
            return Page();
        }

        if (chamado.Status == "Finalizado")
        {
            ModelState.AddModelError("", "Chamado já está finalizado.");
            return Page();
        }

        if (string.IsNullOrWhiteSpace(Solucao))
        {
            ModelState.AddModelError("", "Informe a solução do chamado.");
            return Page();
        }


        chamado.Status = "Finalizado";
        chamado.DataConclusao = DateTime.UtcNow;
        chamado.Solucao = Solucao;

        await _context.SaveChangesAsync();

        return RedirectToPage("/Chamados/List");
    }

}