using Microsoft.VisualStudio.TestTools.UnitTesting;
using VagasApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VagasApi.ViewModels.Tests
{
    [TestClass()]
    public class CreateVagaViewModelTests
    {
        [TestMethod()]
        public void CreateVaga_OK()
        {
            CreateVagaViewModel model = new CreateVagaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                Status = StatusVagaEnum.DISPONIVEL,
                TipoVaga = TipoVagaEnum.COBERTA,
                ValorHora = 10
            };
            var vaga = model.MapTo();

            Assert.IsTrue(model.IsValid);
        }

        [TestMethod()]
        public void CreateVaga_ErroValor()
        {
            CreateVagaViewModel model = new CreateVagaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                Status = StatusVagaEnum.DISPONIVEL,
                TipoVaga = TipoVagaEnum.COBERTA,
                ValorHora = 0
            };
            var vaga = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void CreateVaga_ErroStatus()
        {
            CreateVagaViewModel model = new CreateVagaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                Status = (StatusVagaEnum)11,
                TipoVaga = TipoVagaEnum.COBERTA,
                ValorHora = 10
            };
            var vaga = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void CreateVaga_ErroTipoVaga()
        {
            CreateVagaViewModel model = new CreateVagaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                Status = StatusVagaEnum.DISPONIVEL,
                TipoVaga = (TipoVagaEnum)11,
                ValorHora = 10
            };
            var vaga = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }
    }
}