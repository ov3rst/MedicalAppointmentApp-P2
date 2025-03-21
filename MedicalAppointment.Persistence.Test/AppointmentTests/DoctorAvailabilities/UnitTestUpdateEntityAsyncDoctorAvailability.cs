using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Test.TestContext;
using Moq;

namespace MedicalAppointment.Persistence.Test.AppointmentTests.DoctorAvailabilities
{
    public class UnitTestUpdateEntityAsyncDoctorAvailability
    {
        private readonly IDoctorAvailabilityRepository _repository;
        private readonly Mock<ILoggerService<DoctorAvailabilityRepository>> _logger;
        private DoctorAvailability doctorAvailabilityTest = new DoctorAvailability
        {
            Id = 1,
            DoctorID = 1,
            AvailableDate = DateOnly.FromDateTime(DateTime.Now).AddDays(1),
            StartTime = new TimeOnly(8, 0),
            EndTime = new TimeOnly(18, 0)
        };

        public UnitTestUpdateEntityAsyncDoctorAvailability()
        {
            _logger = new Mock<ILoggerService<DoctorAvailabilityRepository>>();
            _repository = new DoctorAvailabilityRepository(new TestDbContext(), _logger.Object, TestMocksFactory.CreateConfiguration());
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDoctorAvailabilityIsNull()
        {
            //Arrange
            DoctorAvailability doctorAvailability = null!;

            //Act
            string message = "La entidad no puede ser nula";
            var result = await _repository.UpdateEntityAsync(doctorAvailability);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDoctorAvailabilityIdIsZeroOrLessThanZero()
        {
            //Arrange
            doctorAvailabilityTest.Id = -1;

            //Act
            string message = "El DoctorAvailabilityId es invalido";
            var result = await _repository.UpdateEntityAsync(doctorAvailabilityTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDoctorIdIsZeroOrLessThanZero()
        {
            //Arrange
            doctorAvailabilityTest.DoctorID = -1;

            //Act
            string message = "El DoctorId es invalido";
            var result = await _repository.UpdateEntityAsync(doctorAvailabilityTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStartTimeIsLessThanCurrentTime()
        {
            //Arrange
            doctorAvailabilityTest.StartTime = new TimeOnly(7, 59);

            //Act
            string message = "La hora ingresada es invalida";
            var result = await _repository.UpdateEntityAsync(doctorAvailabilityTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenEndTimeIsLessThanCurrentTime()
        {
            //Arrange
            doctorAvailabilityTest.EndTime = new TimeOnly(7, 59);

            //Act
            string message = "La hora ingresada es invalida";
            var result = await _repository.UpdateEntityAsync(doctorAvailabilityTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
