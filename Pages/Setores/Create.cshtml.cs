using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using W5i___Controle_de_Atendimentos.Entities;

public class CreateSetorModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateSetorModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Setor Setor { get; set; } = new Setor();

    public void OnGet()
    {
        Setor = new Setor();
    }


    public async Task<IActionResult> OnPostAsync()
    {

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Setores.Add(Setor);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}