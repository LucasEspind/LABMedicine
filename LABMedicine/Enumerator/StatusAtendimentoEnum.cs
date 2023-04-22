using Microsoft.OpenApi.Attributes;
using System.Text.Json.Serialization;

namespace LABMedicine.Enumerator
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusAtendimentoEnum
    {
        AGUARDANDO_ATENDIMENTO = 0,
        EM_ATENDIMENTO = 1,
        ATENDIDO = 2,
        NAO_ATENDIDO = 3
    }
}
