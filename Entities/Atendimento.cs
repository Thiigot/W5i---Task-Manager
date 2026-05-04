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

        public List<Chamado> ChamadosCriados { get; set; } = new();
        public List<Chamado> ChamadosResolvidos { get; set; } = new();

        [NotMapped]
        public TimeSpan TempoTotal =>
            (DataCheckOut ?? DateTime.UtcNow) - DataCheckIn;
    }
}
