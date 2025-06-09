using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NCM_API.Models
{
    public class Root
    {
         [JsonPropertyName("Data_Ultima_Atualizacao_NCM")]
        public string DataUltimaAtualizacaoNCM { get; set; }= string.Empty;

        [JsonPropertyName("Ato")]
        public string Ato { get; set; }= string.Empty;

        [JsonPropertyName("Nomenclaturas")]
        public List<Nomenclatura>? Nomenclaturas { get; set; }
    
    }
}