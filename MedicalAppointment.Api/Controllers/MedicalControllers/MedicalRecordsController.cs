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
        private readonly IMedicalRecordsRepository _repository;

        public MedicalRecordsController(IMedicalRecordsRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("patientId")]
        public async Task<IActionResult> GetMedicalRecordByPatientId([FromQuery] int patientId)
        {
            var result = await _repository.GetMedicalRecordsByPacientId(patientId);
            return Ok(result);
        }
    }
}
