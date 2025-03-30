namespace PagamentosAPI.ViewModels.Tests
{
    [TestClass()]
    public class CreatePagamentoViewModelTests
    {
        [TestMethod()]
        public void CreatePagamento_OK()
        {
            CreatePagamentoViewModel model = new CreatePagamentoViewModel()
            {
                IdReserva = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                MetodoPagamento = MetodoPagamentoEnum.PIX,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsTrue(model.IsValid);
        }

        [TestMethod()]
        public void CreatePagamento_ErroReserva()
        {
            CreatePagamentoViewModel model = new CreatePagamentoViewModel()
            {
                IdUsuario = Guid.NewGuid(),
                MetodoPagamento = MetodoPagamentoEnum.PIX,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void CreatePagamento_ErroUsuario()
        {
            CreatePagamentoViewModel model = new CreatePagamentoViewModel()
            {
                IdReserva = Guid.NewGuid(),
                MetodoPagamento = MetodoPagamentoEnum.PIX,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void CreatePagamento_ErroMetodoPagamento()
        {
            CreatePagamentoViewModel model = new CreatePagamentoViewModel()
            {
                IdReserva = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                MetodoPagamento = (MetodoPagamentoEnum)11,
                Valor = 10
            };
            var Pagamento = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void CreatePagamento_ErroValor()
        {
            CreatePagamentoViewModel model = new CreatePagamentoViewModel()
            {
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