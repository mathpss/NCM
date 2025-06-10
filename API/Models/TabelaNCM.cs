using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NCM_API.Models
{
    public static class TabelaNCM
    {
        public static List<Nomenclatura> ListaNomenclatura()
        {
            string conteudoArquivo = File.ReadAllText("Tabela_NCM_Vigente_20250608.json");

            Root root = JsonSerializer.Deserialize<Root>(conteudoArquivo);
            return root.Nomenclaturas;
        }
    }
}