using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABMedicine.Models
{
    [Table("Enfermeiros")]
    public class EnfermeirosModel : PessoaModel
    {
        [Required(ErrorMessage = "Por favor insira uma Instituição de Ensino existente!"), Column("Instituicao_de_Ensino")]
        public string InstituicaoEnsino { get; set; }

        [Required(ErrorMessage = "Por favor insira um cadastro do CRM/UF correto!"), Column("Cadastro_CRM/UF")]
        public string CadastroCRM_UF { get; set; }
    }
}
