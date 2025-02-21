using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseController<Notification, int>
    {
        private readonly INotificationRepository _repository;

        public NotificationController(INotificationRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
