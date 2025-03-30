namespace VagasApi.ViewModels.Tests
{
    [TestClass()]
    public class AlterVagaViewModelTests
    {
        [TestMethod()]
        public void AlterVaga_OK()
        {
            AlterVagaViewModel model = new AlterVagaViewModel()
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
        public void AlterVaga_ErroValor()
        {
            AlterVagaViewModel model = new AlterVagaViewModel()
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
        public void AlterVaga_ErroStatus()
        {
            AlterVagaViewModel model = new AlterVagaViewModel()
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
        public void AlterVaga_ErroTipoVaga()
        {
            AlterVagaViewModel model = new AlterVagaViewModel()
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