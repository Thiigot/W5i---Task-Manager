using Microsoft.AspNetCore.Mvc;
using W5i___Controle_de_Atendimentos.Entities;

[ApiController]
[Route("api/[controller]")]
public class SetoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public SetoresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Setor setor)
    {
        _context.Setores.Add(setor);
        await _context.SaveChangesAsync();
        return Ok(setor);
    }

    [HttpGet]
    public IActionResult Listar()
    {
        return Ok(_context.Setores.ToList());
    }
}