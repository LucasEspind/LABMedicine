using LABMedicine.Enumerator;

namespace LABMedicine.DTO
{
    public class AtualizarPacienteDTO
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string ContatoEmergencia { get; set; }
        public List<string>? ListaAlergias { get; set; }
        public List<string>? ListaCuidadosEspecificos { get; set; }
        public string? Convenio { get; set; }
        public StatusAtendimentoEnum StatusAtendimento { get; set; }
        public int TotalAtendimentosRealizados { get; set; }
    }
}
