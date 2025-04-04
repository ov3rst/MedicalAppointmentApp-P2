namespace MedicalAppointment.Web.Models.AppointmentsModels
{
    public class DoctorAvailabilityModel
    {
        public int DoctorAvailabilityId { get; set; }
        public int DoctorID { get; set; }
        public DateOnly AvailableDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
