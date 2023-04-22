using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABMedicine.Models
{
    [Table("Medico")]
    public class MedicoModel : PessoaModel
    {
        [Required, Column("Instituicao_de_Ensino")]
        public string InstituicaoEnsino { get; set; }

        [Required, Column("Cadastro_CRM/UF")]
        public string CadastroCRM_UF { get; set;}

        [Required, Column("Especializacao_Clinica")]
        public EspecializacaoClinicaEnum EspecializacaoClinica { get; set; }

        [Required, Column("Estano_no_Sistema")]
        public EstadoSistemaEnum EstadoSistema { get; set; }

        [Column("Total_de_Atendimentos_Realizados")]
        public int TotalAtendimentosRealizados { get; set; }
    }
}
