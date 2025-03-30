namespace ReservasAPI.ViewModels.Tests
{
    [TestClass()]
    public class CreateReservaViewModelTests
    {
        [TestMethod()]
        public void CreateReserva_OK()
        {
            CreateReservaViewModel model = new CreateReservaViewModel()
            {
                IdEstacionamento = Guid.NewGuid(),
                IdVaga= Guid.NewGuid(),
                IdUsuario = Guid.NewGuid(),
                DataInicio = DateTime.Now.AddDays(10),
                DataFim = DateTime.Now.AddDays(11),
                StatusReserva = StatusReservaEnum.PENDENTE
            };
            var Reserva = model.MapTo();

            Assert.IsTrue(model.IsValid);
        }

        [TestMethod()]
        public void CreateReserva_ErroEstacionamento()
        {
            CreateReservaViewModel model = new CreateReservaViewModel()
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
        public void CreateReserva_ErroVaga()
        {
            CreateReservaViewModel model = new CreateReservaViewModel()
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
        public void CreateReserva_ErroDataInicio()
        {
            CreateReservaViewModel model = new CreateReservaViewModel()
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
        public void CreateReserva_ErroDataFim()
        {
            CreateReservaViewModel model = new CreateReservaViewModel()
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
        public void CreateReserva_ErroStatus()
        {
            CreateReservaViewModel model = new CreateReservaViewModel()
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