using System.ComponentModel.DataAnnotations;

namespace LABMedicine.DTO
{
    public class IdentificadorPacienteMedicoDTO
    {
        [Required]
        public int Identificador_Medico { get; set; }
        [Required]
        public int Identificador_Paciente { get; set; }

    }
}
