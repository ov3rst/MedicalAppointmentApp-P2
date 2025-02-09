using MedicalAppointment.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Insurance
{
    [Table("NetworkType", Schema = "Insurance")]
    public sealed class NetworkType : ActiveEntity<int>
    {
        [Column("NetworkTypeId")]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
