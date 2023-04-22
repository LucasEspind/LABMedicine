using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABMedicine.Models
{
    [Table("Enfermeiro")]
    public class EnfermeiroModel : PessoaModel
    {
        [Required, Column("Instituicao_de_Ensino")]
        public string InstituicaoEnsino { get; set; }

        [Required, Column("Cadastro_CRM/UF")]
        public string CadastroCRM_UF { get; set; }
    }
}
