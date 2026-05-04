using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using W5i___Controle_de_Atendimentos.Entities;

public class CreateChamadoModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateChamadoModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Chamado Chamado { get; set; } = new Chamado();

    public SelectList SetoresSelectList { get; set; }
    public SelectList PrioridadesSelectList { get; set; }

    public void OnGet()
    {
        Chamado = new Chamado();
        var setores = _context.Setores.ToList();
        var prioridades = _context.Prioridades.ToList();

        SetoresSelectList = new SelectList(setores, "Id", "Nome");
        PrioridadesSelectList = new SelectList(prioridades, "Id", "Nome");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var atendimentoId = HttpContext.Session.GetInt32("AtendimentoId");
        if (atendimentoId == null)
        {
            ModelState.AddModelError("", "Você precisa iniciar um atendimento antes de criar um chamado.");

            SetoresSelectList = new SelectList(_context.Setores.ToList(), "Id", "Nome");
            PrioridadesSelectList = new SelectList(_context.Prioridades.ToList(), "Id", "Nome");

            return Page();
        }

        

        if (!ModelState.IsValid)
        {
            foreach (var item in ModelState)
            {
                foreach (var error in item.Value.Errors)
                {
                    Console.WriteLine($"Campo: {item.Key} | Erro: {error.ErrorMessage}");
                }
            }
            SetoresSelectList = new SelectList(_context.Setores, "Id", "Nome");
            PrioridadesSelectList = new SelectList(_context.Prioridades, "Id", "Nome");
            return Page();
        }
        Chamado.AtendimentoCriacaoId = atendimentoId.Value;
        Chamado.Status = "Aberto";
        Chamado.DataCriacao = DateTime.UtcNow;
        _context.Chamados.Add(Chamado);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Chamados/List");
    }

}