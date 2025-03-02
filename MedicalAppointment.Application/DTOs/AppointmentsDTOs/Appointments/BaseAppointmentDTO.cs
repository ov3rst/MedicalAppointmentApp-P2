using MedicalAppointment.Application.DTOs.BaseDTOs;

namespace MedicalAppointment.Application.DTOs.AppointmentsDTOs.Appointments
{
    public abstract record BaseAppointmentDTO : BaseDTO
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int StatusID { get; set; }
    }
}
