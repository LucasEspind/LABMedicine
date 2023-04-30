using LABMedicine.Enumerator;
using System.ComponentModel.DataAnnotations;

namespace LABMedicine.DTO
{
    public class AtualizarMedicoDTO
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string InstituicaoEnsino { get; set; }
        public string CadastroCRM_UF { get; set; }
        [Required(ErrorMessage = "Status inserido de forma inválida!")]
        public EstadoSistemaEnum EstadoSistema { get; set; }
        public EspecializacaoClinicaEnum EspecializacaoClinica { get; set; }
        public int TotalAtendimentosRealizados { get; set; }

    }
}
