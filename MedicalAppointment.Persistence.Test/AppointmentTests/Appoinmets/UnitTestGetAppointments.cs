using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Test.TestContext;
using Moq;

namespace MedicalAppointment.Persistence.Test.AppointmentTests.Appoinmets
{
    public class UnitTestGetAppointments
    {
        private readonly IAppointmentsRepository _repository;
        private readonly Mock<ILoggerService<AppointmentsRepository>> _logger;

        public UnitTestGetAppointments()
        {
            _logger = new Mock<ILoggerService<AppointmentsRepository>>();
            _repository = new AppointmentsRepository(new TestDbContext(), _logger.Object, TestMocksFactory.CreateConfiguration());
        }

        [Fact]
        public async void GetEntityByIdAsync_ShouldReturnFailure_WhenAppointmentIdIsZeroOrLessThanZero()
        {
            //Arrange
            int id = 0;

            //Act
            string message = "El id es invalido";
            var result = await _repository.GetEntityByIdAsync(id);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
