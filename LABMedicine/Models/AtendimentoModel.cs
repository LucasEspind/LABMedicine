using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABMedicine.Models
{
    [Table("Atendimentos")]
    public class AtendimentoModel
    {
        [Key, Column("Codigo_Atendimento")]
        public int Atendimentos { get; set; }
        [Column("Identificador_Medico"), Required]
        public int Identificador_Medico { get; set; }

        [Column("Especialidade_Clinica")]
        public EspecializacaoClinicaEnum especializacaoClinica { get; set; }

        [Column("Identificador_Paciente"), Required]
        public int Identificador_Paciente { get; set; }
    }
}
