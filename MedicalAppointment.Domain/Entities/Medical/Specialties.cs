using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Medical
{
    [Table("Specialties", Schema = "medical")]
    public sealed class Specialties : Base.ActiveEntity<short>
    {
        [Key]
        [Column("SpecialtyID")]
        public override short Id { get; set; }
        public string SpecialtyName { get; set; }
    }
}
