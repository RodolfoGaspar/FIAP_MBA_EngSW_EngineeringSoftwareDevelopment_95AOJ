namespace ReservasAPI.ViewModels.Tests
{
    [TestClass()]
    public class AlterReservaViewModelTests
    {
        [TestMethod()]
        public void AlterReserva_OK()
        {
            AlterReservaViewModel model = new AlterReservaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                IdVaga = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                DataInicio = DateTime.Now.AddDays(10),
                DataFim = DateTime.Now.AddDays(11),
                StatusReserva = StatusReservaEnum.PENDENTE
            };
            var Reserva = model.MapTo();

            Assert.IsTrue(model.IsValid);
        }

        [TestMethod()]
        public void AlterReserva_ErroEstacionamento()
        {
            AlterReservaViewModel model = new AlterReservaViewModel()
            {
                IdVaga = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                DataInicio = DateTime.Now.AddDays(10),
                DataFim = DateTime.Now.AddDays(11),
                StatusReserva = StatusReservaEnum.PENDENTE
            };
            var Reserva = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void AlterReserva_ErroVaga()
        {
            AlterReservaViewModel model = new AlterReservaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                DataInicio = DateTime.Now.AddDays(10),
                DataFim = DateTime.Now.AddDays(11),
                StatusReserva = StatusReservaEnum.PENDENTE
            };
            var Reserva = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void AlterReserva_ErroDataInicio()
        {
            AlterReservaViewModel model = new AlterReservaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                IdVaga = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(11),
                StatusReserva = StatusReservaEnum.PENDENTE
            };
            var Reserva = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void AlterReserva_ErroDataFim()
        {
            AlterReservaViewModel model = new AlterReservaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                IdVaga = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                DataInicio = DateTime.Now.AddDays(10),
                DataFim = DateTime.Now.AddDays(1),
                StatusReserva = StatusReservaEnum.PENDENTE
            };
            var Reserva = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }

        [TestMethod()]
        public void AlterReserva_ErroStatus()
        {
            AlterReservaViewModel model = new AlterReservaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                IdVaga = Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                DataInicio = DateTime.Now.AddDays(10),
                DataFim = DateTime.Now.AddDays(11),
                StatusReserva = (StatusReservaEnum)11
            };
            var Reserva = model.MapTo();

            Assert.IsFalse(model.IsValid);
        }
    }
}