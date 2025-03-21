using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Test.TestContext;
using Moq;

namespace MedicalAppointment.Persistence.Test.AppointmentTests.Appoinmets
{
    public class UnitTestSaveEntityAsyncAppointment
    {
        private readonly IAppointmentsRepository _repository;
        private readonly Mock<ILoggerService<AppointmentsRepository>> _logger;

        private Appointments appointmentTest = new Appointments
        {
            PatientID = 1,
            DoctorID = 1,
            AppointmentDate = DateTime.Now.AddDays(1),
            StatusID = 1,
        };

        public UnitTestSaveEntityAsyncAppointment()
        {
            _logger = new Mock<ILoggerService<AppointmentsRepository>>();
            _repository = new AppointmentsRepository(new TestDbContext(), _logger.Object, TestMocksFactory.CreateConfiguration());
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenAppointmentIsNull()
        {
            //Arrange
            Appointments appointment = null!;

            //Act
            string message = "La entidad no puede ser nula";
            var result = await _repository.SaveEntityAsync(appointment);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenPatientIdIsZeroOrLessThanZero()
        {
            //Arrange
            appointmentTest.PatientID = -1;

            //Act
            string message = "El PatientId es invalido";
            var result = await _repository.SaveEntityAsync(appointmentTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDoctorIdIsZeroOrLessThanZero()
        {
            //Arrange
            appointmentTest.DoctorID = -1;

            //Act
            string message = "El DoctorId es invalido";
            var result = await _repository.SaveEntityAsync(appointmentTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenAppointmentDateIsEqualToOrLessThanCurrentDate()
        {
            //Arrange
            appointmentTest.AppointmentDate = DateTime.UtcNow.AddDays(-1);

            //Act
            string message = "La fecha ingresada es invalida";
            var result = await _repository.SaveEntityAsync(appointmentTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStatusIdIsZeroOrLessThanZero()
        {
            //Arrange
            appointmentTest.StatusID = -1;

            //Act
            string message = "El StatusId es invalido";
            var result = await _repository.SaveEntityAsync(appointmentTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
