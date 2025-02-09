using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Medical
{
    [Table("AvailabilityModes", Schema = "medical")]
    public sealed class AvailabilityModes : Base.ActiveEntity<short>
    {
        [Key]
        [Column("SAvailabilityModeID")]
        public override short Id { get; set; }
        public string AvailabilityMode { get; set; }
    }
}
