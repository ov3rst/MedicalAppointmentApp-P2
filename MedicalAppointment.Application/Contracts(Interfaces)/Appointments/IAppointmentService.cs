using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.AppointmentsDTOs.Appointments;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Appointments
{
    public interface IAppointmentService : IBaseService<SaveAppointmentDTO, UpdateAppointmentDTO, RemoveAppointmentDTO, int>
    {
    }
}
