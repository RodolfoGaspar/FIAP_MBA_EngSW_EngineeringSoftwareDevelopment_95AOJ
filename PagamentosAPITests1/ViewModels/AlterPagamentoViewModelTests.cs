using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentosAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class AlterPagamentoViewModelTests
    {
        [TestMethod()]
        public void AlterPagamento_OK()
        {
            AlterPagamentoViewModel model = new AlterPagamentoViewModel()
            {
                Id = Guid.NewGuid(),
                IdReserva = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                MetodoPagamento = MetodoPagamentoEnum.PIX,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsTrue(model.IsValid);
        }

        [TestMethod()]
        public void AlterPagamento_ErroId()
        {
            AlterPagamentoViewModel model = new AlterPagamentoViewModel()
            {
                IdUsuario = Guid.NewGuid(),
                MetodoPagamento = MetodoPagamentoEnum.PIX,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void AlterPagamento_ErroReserva()
        {
            AlterPagamentoViewModel model = new AlterPagamentoViewModel()
            {
                Id = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                MetodoPagamento = MetodoPagamentoEnum.PIX,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void AlterPagamento_ErroUsuario()
        {
            AlterPagamentoViewModel model = new AlterPagamentoViewModel()
            {
                Id = Guid.NewGuid(),
                IdReserva = Guid.NewGuid(),
                MetodoPagamento = MetodoPagamentoEnum.PIX,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void AlterPagamento_ErroMetodoPagamento()
        {
            AlterPagamentoViewModel model = new AlterPagamentoViewModel()
            {
                Id = Guid.NewGuid(),
                IdReserva = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                MetodoPagamento = (MetodoPagamentoEnum)11,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void AlterPagamento_ErroValor()
        {
            AlterPagamentoViewModel model = new AlterPagamentoViewModel()
            {
                Id = Guid.NewGuid(),
                IdReserva = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                MetodoPagamento = MetodoPagamentoEnum.PIX,
                Valor = 0
            };
            var Pagamento = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }
    }
}