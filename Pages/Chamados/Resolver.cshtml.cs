using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        if (chamado.Status == "Finalizado")
            return BadRequest("Chamado já finalizado");

        chamado.Status = "Finalizado";
        chamado.DataConclusao = DateTime.UtcNow;
        chamado.Solucao = Solucao;

        await _context.SaveChangesAsync();

        return RedirectToPage("/Chamados/List");
    }
}