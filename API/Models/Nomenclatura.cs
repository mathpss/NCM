using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NCM_API.Models
{
    public class Nomenclatura
    {
        [JsonPropertyName("Codigo")]
        public string Codigo { get; set; } = string.Empty;

        [JsonPropertyName("Descricao")]
        public string Descricao { get; set; }= string.Empty;

        [JsonPropertyName("Data_Inicio")]
        public string DataInicio { get; set; }= string.Empty;

        [JsonPropertyName("Data_Fim")]
        public string DataFim { get; set; }= string.Empty;

        [JsonPropertyName("Tipo_Ato_Ini")]
        public string TipoAtoIni { get; set; }= string.Empty;

        [JsonPropertyName("Numero_Ato_Ini")]
        public string NumeroAtoIni { get; set; }= string.Empty;

        [JsonPropertyName("Ano_Ato_Ini")]
        public string AnoAtoIni { get; set; }= string.Empty;
    }
}