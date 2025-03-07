﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Domain.Entities.Users
{
    [Table("Doctors", Schema = "users")]
    public sealed class Doctor : Base.ActiveEntity<int>
    {
        [Key]
        [ForeignKey("User")]
        [Column("DoctorID")]
        public override int Id { get; set; }

        [ForeignKey("SpecialtyID")]
        public short SpecialtyID { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string Education { get; set; }
        public string? Bio { get; set; }
        public decimal? ConsultationFee { get; set; }
        public string? ClinicAddress { get; set; }

        [ForeignKey("AvailabilityModeId")]
        public short? AvailabilityModeId { get; set; }
        public DateOnly LicenseExpirationDate { get; set; }
    }
}
