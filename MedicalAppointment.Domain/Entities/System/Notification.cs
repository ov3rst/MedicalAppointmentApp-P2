using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.System
{
    [Table("Notification", Schema = "system")]
    public sealed class Notification : Base.BaseEntity<int>
    {
        [Column("NotificationID")]
        [Key]
        public override int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime? SendAt { get; set; }
    }
}
