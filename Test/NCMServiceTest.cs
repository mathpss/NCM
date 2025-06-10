using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NCM_API.Controllers;
using NCM_API.Models;
using NCM_API.Service.Interfaces;
using Xunit;

namespace Test
{
    public class NCMServiceTest
    {
        private readonly Mock<INCMService> _ncmService;
        private readonly NCMController _ncmController;
        public NCMServiceTest()
        {
            _ncmService = new Mock<INCMService>();
            _ncmController = new NCMController(_ncmService.Object);
        }

        [Fact]
        public void ObterNCM_RetornoOK()
        {
            //Arrange
            string ncm = "0101.21.00";
            var nomenclatura = new Nomenclatura
            {
                Codigo = "0101.21.00",
                Descricao = "-- Reprodutores de raça pura",
                DataInicio = "01/04/2022",
                DataFim = "31/12/9999",
                TipoAtoIni = "Res Camex",
                NumeroAtoIni = "272",
                AnoAtoIni = "2021"
            };
            _ncmService.Setup(x => x.BuscarNCM(ncm)).Returns(nomenclatura);

            //Act
            var result = _ncmController.ObterNCM(ncm);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualValue = Assert.IsType<Nomenclatura>(okResult.Value);
            //var actualValue = Assert.IsAssignableFrom<Nomenclatura>(okResult.Value);

            Assert.Equal(nomenclatura, actualValue);
            _ncmService.Verify(x => x.BuscarNCM(ncm), Times.Once);
        }

        [Fact]
        public void BucaPorPalavras()
        {
            //Arrange
            string palavra = "Reatores nucleares caldeiras";
            var ListaNomenclatura = new Nomenclatura
            {
                Codigo = "8467.29.10",
                Descricao = "Capítulo: Reatores nucleares, caldeiras, máquinas, aparelhos e instrumentos mecânicos, e suas partes. Posição: Ferramentas pneumáticas, hidráulicas ou com motor (elétrico ou não elétrico) incorporado, de uso manual. Subposição: - Com motor elétrico incorporado:-- Outras Subitem: Tesouras",
                DataInicio = "01/04/2022",
                DataFim = "31/12/9999",
                TipoAtoIni = "Res Camex",
                NumeroAtoIni = "272",
                AnoAtoIni = "2021"
            };

            var resultExpected = new List<Nomenclatura> { ListaNomenclatura };
            _ncmService.Setup(x => x.BuscaPorPalavras(palavra)).Returns(resultExpected);

            //Act
            var result = _ncmController.BucaPorPalavras(palavra);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualValue = Assert.IsType<List<Nomenclatura>>(okResult.Value);
            //var actualValue = Assert.IsAssignableFrom<Nomenclatura>(okResult.Value);

            Assert.Equal(resultExpected, actualValue);
            _ncmService.Verify(x => x.BuscaPorPalavras(palavra), Times.Once);

        }
    }
}