using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Appointments
{
    [Table("DoctorAvailability", Schema = "appointmnets")]
    public sealed class DoctorAvailability : Base.BaseEntity<int>
    {
        [Column("AvailabilityID")]
        [Key]
        public override int Id { get; set; }
        public int DoctorID { get; set; }
        public DateOnly AvailableDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
