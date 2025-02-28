namespace MedicalAppointment.Application.DTOs.AppointmentsDTOs.Appointments
{
    public abstract record BaseAppointmentDTO
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int StatusID { get; set; }
    }
}
