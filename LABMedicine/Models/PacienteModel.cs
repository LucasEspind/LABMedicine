using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LABMedicine.Models
{
    [Table("Paciente")]
    public class PacienteModel : PessoaModel
    {
        [MaxLength(100), Required, NotNull, Column("Contato_de_Emergencia")]
        public string ContatoEmergencia { get; set; }

        [Column("Lista_de_Alergias")]
        public string? ListaAlergias { get; set; }

        [Column("Lista_de_Cuidados_Especificos")]
        public string? ListaCuidadosEspecificos { get; set; }

        [MaxLength(100), Column("Convenio")]
        public string? Convenio { get; set; }

        [Column("Status_Atendimento")]
        public StatusAtendimentoEnum StatusAtendimento { get; set;}

        [Column("Total_de_Atendimentos_Realizado")]
        public int TotalAtendimentosRealizados { get; set; }
        
    }
}
