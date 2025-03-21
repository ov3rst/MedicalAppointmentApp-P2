using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using MedicalAppointment.Persistence.Repositories.InsuranceRepositories;
using MedicalAppointment.Persistence.Test.TestContext;
using Moq;

namespace MedicalAppointment.Persistence.Test.InsuranceTests.Insurances
{
    public class UnitTestSaveEntityAsyncInsuranceProvider
    {
        private readonly IInsuranceProviderRepository _repository;
        private readonly Mock<ILoggerService<InsuranceProviderRepository>> _logger;

        private InsuranceProvider insuranceTest = new()
        {
            Name = "Test",
            ContactNumber = "809-555-4444",
            Email = "testinsurance@test.com",
            Website = string.Empty,
            Address = "Calle jardin celestial",
            City = string.Empty,
            State = string.Empty,
            Country = string.Empty,
            ZipCode = string.Empty,
            CoverageDetails = "cubre esto, cubre aquello",
            LogoUrl = string.Empty,
            IsPreferred = false,
            NetworkTypeId = 1,
            CustomerSupportContact = string.Empty,
            AcceptedRegions = string.Empty,
            MaxCoverageAmount = 0,
        };

        public UnitTestSaveEntityAsyncInsuranceProvider()
        {
            _logger = new Mock<ILoggerService<InsuranceProviderRepository>>();
            _repository = new InsuranceProviderRepository(new TestDbContext(), _logger.Object, TestMocksFactory.CreateConfiguration());
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceProviderIsNull()
        {
            //Arrange
            InsuranceProvider insurance = null!;

            //Act
            string message = "La entidad no puede ser nula";
            var result = await _repository.SaveEntityAsync(insurance);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceNameExceedsLength()
        {
            //Arrange
            insuranceTest.Name = "ñadldsgdsgdkjgkdjslgjkdjsjdsjkdjhdkjsghjhdsghjshgjdhsjghsdhghkjshgdghdklsgkdsgjgsdgsdgdsgdsgdsgsgsdsgdsgdsgds";

            //Act
            string message = "El limite de carácteres es mayor al permitido";
            var result = await _repository.SaveEntityAsync(insuranceTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceNameContainsNumbers()
        {
            //Arrange
            insuranceTest.Name = "0l1v3r T3j3d4";

            //Act
            string message = "Esta propiedad no debe contener numeros";
            var result = await _repository.SaveEntityAsync(insuranceTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceNameIsEmpty()
        {
            //Arrange
            insuranceTest.Name = string.Empty;

            //Act
            string message = "Esta propiedad no puede estar vacia";
            var result = await _repository.SaveEntityAsync(insuranceTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceContactNumberIsInvalid()
        {
            //Arrange
            insuranceTest.ContactNumber = "800-528-52344";

            //Act
            string message = "El número de teléfono es invalido";
            var result = await _repository.SaveEntityAsync(insuranceTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceEmailIsInvalid()
        {
            //Arrange
            insuranceTest.Email = "tyreyer@asd";

            //Act
            string message = "El email es invalido";
            var result = await _repository.SaveEntityAsync(insuranceTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceWebsiteIsInvalid()
        {
            //Arrange
            insuranceTest.Website = "htp://www.asfasf";

            //Act
            string message = "La URL es invalida";
            var result = await _repository.SaveEntityAsync(insuranceTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceAddressExceedsLength()
        {
            //Arrange
            insuranceTest.Address = "ñadldsgdsgdkjgkdjslgjkdjsjdsjkdjhdkjsghjhdsghjshgjdhsjghsdhghkjshgdghdklsgkdsgjgsdgsdgdsgdsgdsgsgsdsgdsgdsgdsasfjakjfklajkjgkljasfjasfkjjasfjajfjajsfkjjaskfjajsfkjasjfkljaksfjjafjakjfkjaksjfkajsfjakjfkljajsfjafjasjfkjasjfajsfjkajfkjaksjfkjasfjkajfkjasfkjkasjfklajkfjasfjkajfkljakfjjasghahgljañkjgklfjgkljakvndvavkhjrjshvjanv";

            //Act
            string message = "La dirección es invalida";
            var result = await _repository.SaveEntityAsync(insuranceTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenInsuranceAddressIsInvalid()
        {
            //Arrange
            insuranceTest.Address = "ksfkakefjkea·$%/%$·";

            //Act
            string message = "La dirección es invalida";
            var result = await _repository.SaveEntityAsync(insuranceTest);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        // de address para adelante seguir desde ahi
    }
}
