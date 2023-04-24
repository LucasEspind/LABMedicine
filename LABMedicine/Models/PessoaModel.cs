using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LABMedicine.Models
{ 
    abstract public class PessoaModel
    {
        [Key, Column("Identificado")]
        public int Identificador { get; set; }
        [Column("Nome_Completo"), Required(ErrorMessage = "Por favor insira um nome de forma correta!")]
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }

        [Required(ErrorMessage = "Por favor digite uma data de nascimento válida!"), Column("Data_de_Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Cpf inválido! Verifique se está preenchendo os 11 números corretamente, sem pontos ou traços!")]
        public string CPF { get; set; }
        public string Telefone { get; set; } 
    }
}
