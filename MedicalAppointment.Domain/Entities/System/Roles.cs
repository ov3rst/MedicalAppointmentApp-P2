using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.System
{
    [Table("Roles", Schema = "system")]
    public sealed class Roles : Base.ActiveEntity<int>
    {
        [Key]
        [Column("RoleID")]
        public override int Id { get; set; }
        public string RoleName { get; set; }
    }
}
