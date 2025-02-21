using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController<Status, int>
    {
        private readonly IStatusRepository _repository;

        public StatusController(IStatusRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
