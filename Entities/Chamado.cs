using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace W5i___Controle_de_Atendimentos.Entities
{
    public class Chamado
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        [Required]
        public int SetorID { get; set; }
        [Required]
        public int PrioridadeID { get; set; }
        public string Status { get; set; } = "Aberto";
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataConclusao { get; set; }
        public String? Solucao { get; set; }
        public Setor? Setor { get; set; }
        public Prioridade? Prioridade { get; set; }
        [NotMapped]
        public bool EstaQuaseAtrasado
        {
            get
            {
                if (Prioridade == null)
                    return false;

                var limite = DataCriacao.AddHours(Prioridade.TempoEstimadoHoras);
                var agora = DateTime.UtcNow;

                return !EstaAtrasado && (limite - agora).TotalHours <= 1;
            }
        }
        [NotMapped]
        public bool EstaAtrasado
        {
            get
            {
                if (Prioridade == null)
                    return false;

                var limite = DataCriacao.AddHours(Prioridade.TempoEstimadoHoras);
                var referencia = DataConclusao ?? DateTime.UtcNow;
                return referencia > limite;
            }
        }

        [NotMapped]
        public TimeSpan TempoTotalAtendimento
        {
            get
            {
                var fim = DataConclusao ?? DateTime.UtcNow;
                return fim - DataCriacao;
            }
        }
        [NotMapped]
        public string TempoTotalFormatado
        {
            get
            {
                var tempo = TempoTotalAtendimento;
                return $"{(int)tempo.TotalHours}h {tempo.Minutes}m";
            }
        }
    }
}
