using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Medical
{
    [Table("MedicalRecords", Schema = "medical")]
    public sealed class MedicalRecords : Base.AuditEntity<int>
    {
        [Key]
        [Column("RecordID")]
        public override int Id { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }
    }
}
