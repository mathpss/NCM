using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NCM_API.Models;
using NCM_API.Service.Interfaces;

namespace NCM_API.Service
{
    public class NCMService : INCMService
    {
        private List<Nomenclatura> nomenclaturas { get; set; } = TabelaNCM.ListaNomenclatura();
        public Nomenclatura BuscarNCM(string ncm)
        {
            StringBuilder DescricaoFormatada = new StringBuilder();

            if (Regex.IsMatch(ncm, @"^\d{4}\.\d{2}\.\d{2}$"))
            {
                var existeLista = nomenclaturas.Where(x => x.Codigo == ncm).FirstOrDefault();
                if (existeLista != null)
                {
                    var codigo2 = existeLista.Codigo[0..2];
                    var codigo4 = existeLista.Codigo[0..4];
                    string insert = ".";
                    string result = codigo4.Insert(2, insert);

                    var codigo5 = existeLista.Codigo[0..6];
                    var codigo6 = existeLista.Codigo[0..7];
                    var codigo7 = existeLista.Codigo[0..9];


                    var checkCodigo2 = nomenclaturas.Where(x => x.Codigo == codigo2).FirstOrDefault();
                    var checkCodigo4 = nomenclaturas.Where(x => x.Codigo == result).FirstOrDefault();

                    var checkCodigo5 = nomenclaturas.Where(x => x.Codigo == codigo5).FirstOrDefault();
                    var checkCodigo6 = nomenclaturas.Where(x => x.Codigo == codigo6).FirstOrDefault();
                    var checkCodigo7 = nomenclaturas.Where(x => x.Codigo == codigo7).FirstOrDefault();

                    if (checkCodigo2 != null)
                    {
                        DescricaoFormatada.Append($"Capítulo: {checkCodigo2.Descricao}");
                    }


                    if (checkCodigo4 != null)
                    {
                        DescricaoFormatada.Append($" Posição: {checkCodigo4.Descricao}");
                    }


                    if (checkCodigo5 != null && checkCodigo5.Descricao != "- Outros:")
                    {
                        DescricaoFormatada.Append($" Subposição: {checkCodigo5.Descricao}");
                    }

                    if (checkCodigo6 != null && checkCodigo5 == null)
                    {
                        DescricaoFormatada.Append($" Subposição: {checkCodigo6.Descricao}");
                    }

                    if (checkCodigo6 != null)
                    {
                        DescricaoFormatada.Append(checkCodigo6.Descricao);
                    }

                    if (checkCodigo7 != null)
                    {
                        DescricaoFormatada.Append($" Item: {checkCodigo7.Descricao}");
                    }

                    DescricaoFormatada.Append($" Subitem: {existeLista.Descricao}");


                    return new Nomenclatura
                    {
                        Codigo = existeLista.Codigo,
                        Descricao = DescricaoFormatada.ToString(),
                        DataInicio = existeLista.DataInicio,
                        DataFim = existeLista.DataFim,
                        TipoAtoIni = existeLista.TipoAtoIni,
                        NumeroAtoIni = existeLista.NumeroAtoIni,
                        AnoAtoIni = existeLista.AnoAtoIni
                    };

                }
            }

            return new();
        }

        public List<Nomenclatura> BuscaPorPalavras(string busca)
        {
            List<Nomenclatura> listaDescriçaoFormatada = NomenclaturasFormatadas();
            List<Nomenclatura> listaBuscada = new();

            var buscaEditada = busca.Split(' ');

            foreach (var item in buscaEditada)
            {
                listaBuscada = listaDescriçaoFormatada.Where(x => x.Descricao.Contains(item, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return listaBuscada;
        }

        public List<Nomenclatura> BuscaPor4Digitos(string ncm)
        {
            if (!Regex.IsMatch(ncm, @"^\d{4}$")) throw new ArgumentException("Formato errado");

            List<Nomenclatura> listaDescriçaoFormatada = NomenclaturasFormatadas();
            List<Nomenclatura> listaBuscada = new();

            return listaBuscada = listaDescriçaoFormatada.Where(x => x.Codigo.Contains(ncm)).ToList();

        }

        private List<Nomenclatura> NomenclaturasFormatadas()
        {
            List<Nomenclatura> listaDescriçaoFormatada = new();
            var ListaNomenclatura = nomenclaturas.Where(x => x.Codigo.Length == 10);

            foreach (var item in ListaNomenclatura)
            {
                listaDescriçaoFormatada.Add(BuscarNCM(item.Codigo));
            }
            return listaDescriçaoFormatada;
        }
    }
}