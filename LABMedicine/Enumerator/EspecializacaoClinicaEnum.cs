using Microsoft.OpenApi.Attributes;
using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EspecializacaoClinicaEnum
    {
        [Display("Clínico Geral")]
        Clínico_Geral = 0,
        Anestesista = 1,
        Dermatologia = 2,
        Ginecologia = 3,
        Neurologia = 4,
        Pediatria = 5,
        Psiquiatria = 6,
        Ortopedia = 7
    }
}
