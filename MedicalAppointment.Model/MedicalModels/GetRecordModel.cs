namespace MedicalAppointment.Model.MedicalModels
{
    public class GetRecordModel
    {
        public int RecordId { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }
    }
}
