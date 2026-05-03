using System.ComponentModel.DataAnnotations;

namespace W5i___Controle_de_Atendimentos.Entities
{
    public class Setor
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
    }
}
