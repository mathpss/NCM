using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCM_API.Models;

namespace NCM_API.Service.Interfaces
{
    public interface INCMService
    {
        public Nomenclatura BuscarNCM(string ncm);

        public List<Nomenclatura> BuscaPorPalavras(string busca);

        public List<Nomenclatura> BuscaPor4Digitos(string ncm);
    }
}