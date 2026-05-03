using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using W5i___Controle_de_Atendimentos.Entities;

public class CreatePrioridadeModel : PageModel
{
    private readonly AppDbContext _context;

    public CreatePrioridadeModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Prioridade Prioridade { get; set; } = new Prioridade();

    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine("Entrou no POST PRIORIDADE");

        if (!ModelState.IsValid)
        {
            Console.WriteLine("Model inválido!");
            return Page();
        }

        Console.WriteLine($"Nome: {Prioridade.Nome}");
        Console.WriteLine($"Tempo: {Prioridade.TempoEstimadoHoras}");

        _context.Prioridades.Add(Prioridade);
        await _context.SaveChangesAsync();

        Console.WriteLine("Salvou prioridade");

        return RedirectToPage("/Index");
    }
}