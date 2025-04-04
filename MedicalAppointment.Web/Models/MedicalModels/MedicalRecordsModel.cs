namespace MedicalAppointment.Web.Models.MedicalModels
{
    public class MedicalRecordsModel
    {
        public int MedicalRecordsId { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }
    }
}
