using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.MedicalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : BaseController<MedicalRecords, int>
    {
        private readonly IMedicalRecordsRepository _medicalRecordsRepository;

        public MedicalRecordsController(IMedicalRecordsRepository medicalRecordsRepository) : base(medicalRecordsRepository)
        {
            _medicalRecordsRepository = medicalRecordsRepository;
        }
    }
}
