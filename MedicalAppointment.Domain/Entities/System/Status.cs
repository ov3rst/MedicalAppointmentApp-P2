using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.System
{
    [Table("Status", Schema = "system")]
    public sealed class Status : Base.BaseEntity<int>
    {
        [Column("StatusID")]
        [Key]
        public override int Id { get; set; }
        public string StatusName { get; set; }
    }
}
