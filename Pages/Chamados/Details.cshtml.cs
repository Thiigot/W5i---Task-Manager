using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using W5i___Controle_de_Atendimentos.Entities;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public Chamado Chamado { get; set; }

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet(int id)
    {
        Chamado = _context.Chamados
            .Include(c => c.Prioridade)
            .Include(c => c.Setor)
            .FirstOrDefault(c => c.Id == id);

        if (Chamado == null)
            return NotFound();

        return Page();
    }
}