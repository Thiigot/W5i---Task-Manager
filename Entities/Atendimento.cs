using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W5i___Controle_de_Atendimentos.Entities
{
    public class Atendimento
    {
        public int Id { get; set; }

        [Required]
        public string Funcionario { get; set; } = string.Empty;

        public DateTime DataCheckIn { get; set; } = DateTime.UtcNow;

        public DateTime? DataCheckOut { get; set; }
        public int? TotalChamadosCriados { get; set; }
        public int? TotalChamadosResolvidos { get; set; }

        // Relacionamento com chamados
        public List<Chamado>? Chamados { get; set; } = new List<Chamado>(); 

        // Calculado
        [NotMapped]
        public TimeSpan TempoTotal =>
            (DataCheckOut ?? DateTime.UtcNow) - DataCheckIn;
    }
}
