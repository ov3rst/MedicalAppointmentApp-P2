using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.SystemDTOs.Notification;

namespace MedicalAppointment.Application.Contracts_Interfaces_.System
{
    public interface INotificationService : IBaseService<SaveNotificationDTO, UpdateNotificationDTO, RemoveNotificationDTO, int>
    {
    }
}
