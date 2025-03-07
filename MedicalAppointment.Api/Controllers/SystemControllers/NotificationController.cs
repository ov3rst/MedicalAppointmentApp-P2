using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.System;
using MedicalAppointment.Application.DTOs.SystemDTOs.Notification;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseController<SaveNotificationDTO, UpdateNotificationDTO, RemoveNotificationDTO, int>
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service) : base(service)
        {
            _service = service;
        }
    }
}
