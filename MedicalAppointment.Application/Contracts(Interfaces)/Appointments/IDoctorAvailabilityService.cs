using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.AppointmentsDTOs.DoctorAvailability;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Appointments
{
    public interface IDoctorAvailabilityService : IBaseService<SaveDoctorAvailabilityDTO, UpdateDoctorAvailabilityDTO, RemoveDoctorAvailabilityDTO, int>
    {
    }
}
