namespace MedicalAppointment.Application.DTOs.AppointmentsDTOs.DoctorAvailability
{
    public abstract record BaseDoctorAvailabilityDTO
    {
        public int DoctorID { get; set; }
        public DateOnly AvailableDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
