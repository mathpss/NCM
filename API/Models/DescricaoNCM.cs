using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCM_API.Models
{
    public class DescricaoNCM(string capitulo, string posicao, string subposicao, string item, string subitem)
    {
        public string Capitulo { get; set; } = capitulo != string.Empty ? capitulo :  throw new ArgumentNullException("");
        public string Posicao { get; set; }
        public string Subposicao { get; set; }
        public string Item { get; set; }
        public string Subitem { get; set; }
    }
}