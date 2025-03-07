using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Medical;
using MedicalAppointment.Application.DTOs.MedicalDTOs.MedicalRecords;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.MedicalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : BaseController<SaveMedicalRecordsDTO, UpdateMedicalRecordsDTO, RemoveMedicalRecordsDTO, int>
    {
        private readonly IMedicalRecordService _service;

        public MedicalRecordsController(IMedicalRecordService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("patientId")]
        public async Task<IActionResult> GetMedicalRecordByPatientId([FromQuery] int patientId)
        {
            var result = await _service.GetMedicalRecordsByPacientId(patientId);
            return Ok(result);
        }
    }
}
