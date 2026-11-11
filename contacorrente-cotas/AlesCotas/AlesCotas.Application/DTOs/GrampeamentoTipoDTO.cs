using System.Text.Json.Serialization;

namespace AlesCotas.Application.DTOs
{
    public class GrampeamentoTipoDTO
    {
        [JsonPropertyName("IDGrapeamentoTipo")]
        public int IDGrampeamentoTipo { get; set; }

        [JsonPropertyName("Nome")]
        public string Nome { get; set; }
    }
}
