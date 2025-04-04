namespace MedicalAppointment.Web.Models.AppointmentsModels
{
    public class AppointmentsModel
    {
        public int AppointmentId { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int StatusID { get; set; }
    }
}
